using Microsoft.Data.Sqlite;

namespace HSTechService
{
    public static class Database
    {
        private const int VersaoAtual = 3;
        private const int MaxBackupsAutomaticos = 10;

        private static readonly string pasta = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "HSTechService");

        private static readonly string pastaBackups = Path.Combine(pasta, "Backups");
        private static readonly string caminho = Path.Combine(pasta, "hstechservice.db");

        public static string Pasta => pasta;

        public static SqliteConnection Abrir()
        {
            var con = new SqliteConnection($"Data Source={caminho}");
            con.Open();

            using var cmd = con.CreateCommand();
            cmd.CommandText = "PRAGMA foreign_keys = ON; PRAGMA busy_timeout = 5000;";
            cmd.ExecuteNonQuery();

            return con;
        }

        public static void Inicializar()
        {
            Directory.CreateDirectory(pasta);
            Directory.CreateDirectory(pastaBackups);

            using var con = Abrir();
            int versao = LerVersao(con);

            if (versao > VersaoAtual)
            {
                throw new InvalidOperationException(
                    "Este banco de dados foi criado por uma versão mais nova do sistema. Atualize o HSTechService.");
            }

            // Banco criado pelas primeiras versões, antes do controle de versão.
            if (versao == 0 && TabelaExiste(con, "clientes"))
                versao = 1;

            if (versao < 1)
                Migrar(con, 1, SchemaV1);

            if (versao < 2)
                Migrar(con, 2, SchemaV2);

            if (versao < 3)
                Migrar(con, 3, SchemaV3);
        }

        public static void Backup(string destino)
        {
            using var origem = Abrir();
            using var copia = new SqliteConnection($"Data Source={destino};Pooling=False");
            copia.Open();
            origem.BackupDatabase(copia);
        }

        public static void BackupAutomatico()
        {
            try
            {
                Directory.CreateDirectory(pastaBackups);
                Backup(Path.Combine(pastaBackups, $"auto-{DateTime.Now:yyyyMMdd-HHmmss}.db"));

                var antigos = new DirectoryInfo(pastaBackups)
                    .GetFiles("auto-*.db")
                    .OrderByDescending(f => f.Name)
                    .Skip(MaxBackupsAutomaticos);

                foreach (var arquivo in antigos)
                    arquivo.Delete();
            }
            catch
            {
                // O backup automático nunca deve impedir o fechamento do sistema.
            }
        }

        public static void Restaurar(string arquivo)
        {
            ValidarBackup(arquivo);

            Directory.CreateDirectory(pastaBackups);
            Backup(Path.Combine(pastaBackups, $"antes-restaurar-{DateTime.Now:yyyyMMdd-HHmmss}.db"));

            SqliteConnection.ClearAllPools();
            File.Copy(arquivo, caminho, true);
        }

        private static void ValidarBackup(string arquivo)
        {
            using var con = new SqliteConnection($"Data Source={arquivo};Mode=ReadOnly;Pooling=False");
            con.Open();

            using var cmd = con.CreateCommand();

            cmd.CommandText = "PRAGMA integrity_check";
            if (cmd.ExecuteScalar()?.ToString() != "ok")
                throw new InvalidDataException("O arquivo está corrompido.");

            cmd.CommandText = @"
SELECT COUNT(*) FROM sqlite_master
WHERE type = 'table' AND name IN ('usuarios', 'clientes', 'equipamentos', 'ordens_servico')";
            if (Convert.ToInt32(cmd.ExecuteScalar()) != 4)
                throw new InvalidDataException("O arquivo selecionado não é um backup do HSTechService.");
        }

        private static int LerVersao(SqliteConnection con)
        {
            using var cmd = con.CreateCommand();
            cmd.CommandText = "PRAGMA user_version";
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static bool TabelaExiste(SqliteConnection con, string nome)
        {
            using var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = @nome";
            cmd.Parameters.AddWithValue("@nome", nome);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private static void Migrar(SqliteConnection con, int versao, string script)
        {
            using var tx = con.BeginTransaction();
            using var cmd = con.CreateCommand();
            cmd.Transaction = tx;
            cmd.CommandText = script + $"\nPRAGMA user_version = {versao};";
            cmd.ExecuteNonQuery();
            tx.Commit();
        }

        private const string SchemaV1 = @"
CREATE TABLE IF NOT EXISTS usuarios (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    login TEXT NOT NULL UNIQUE,
    senha_hash TEXT NOT NULL,
    salt TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS clientes (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    nome TEXT NOT NULL,
    cpf_cnpj TEXT NOT NULL DEFAULT '',
    telefone TEXT NOT NULL DEFAULT '',
    whatsapp TEXT NOT NULL DEFAULT '',
    email TEXT NOT NULL DEFAULT '',
    endereco TEXT NOT NULL DEFAULT '',
    numero TEXT NOT NULL DEFAULT '',
    bairro TEXT NOT NULL DEFAULT '',
    cidade TEXT NOT NULL DEFAULT '',
    data_cadastro TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS equipamentos (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    cliente_id INTEGER NOT NULL,
    tipo TEXT NOT NULL,
    marca TEXT NOT NULL DEFAULT '',
    modelo TEXT NOT NULL DEFAULT '',
    numero_serie TEXT NOT NULL DEFAULT '',
    senha TEXT NOT NULL DEFAULT '',
    processador TEXT NOT NULL DEFAULT '',
    memoria TEXT NOT NULL DEFAULT '',
    armazenamento TEXT NOT NULL DEFAULT '',
    acessorios TEXT NOT NULL DEFAULT '',
    observacoes TEXT NOT NULL DEFAULT '',
    FOREIGN KEY (cliente_id) REFERENCES clientes(id)
);

CREATE TABLE IF NOT EXISTS ordens_servico (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    cliente_id INTEGER NOT NULL,
    equipamento_id INTEGER NOT NULL,
    data_entrada TEXT NOT NULL,
    status TEXT NOT NULL DEFAULT 'Aguardando',
    defeito_relatado TEXT NOT NULL DEFAULT '',
    laudo TEXT NOT NULL DEFAULT '',
    valor REAL NOT NULL DEFAULT 0,
    data_entrega TEXT,
    FOREIGN KEY (cliente_id) REFERENCES clientes(id),
    FOREIGN KEY (equipamento_id) REFERENCES equipamentos(id)
);";

        private const string SchemaV2 = @"
ALTER TABLE usuarios ADD COLUMN recovery_hash TEXT;
ALTER TABLE usuarios ADD COLUMN recovery_salt TEXT;
ALTER TABLE usuarios ADD COLUMN tentativas INTEGER NOT NULL DEFAULT 0;
ALTER TABLE usuarios ADD COLUMN bloqueado_ate TEXT;

CREATE TABLE IF NOT EXISTS configuracoes (
    chave TEXT PRIMARY KEY,
    valor TEXT NOT NULL DEFAULT ''
);

CREATE INDEX IF NOT EXISTS idx_clientes_nome ON clientes(nome);
CREATE INDEX IF NOT EXISTS idx_clientes_cpf ON clientes(cpf_cnpj);
CREATE INDEX IF NOT EXISTS idx_equipamentos_cliente ON equipamentos(cliente_id);
CREATE INDEX IF NOT EXISTS idx_os_cliente ON ordens_servico(cliente_id);
CREATE INDEX IF NOT EXISTS idx_os_equipamento ON ordens_servico(equipamento_id);
CREATE INDEX IF NOT EXISTS idx_os_status ON ordens_servico(status);
CREATE INDEX IF NOT EXISTS idx_os_data ON ordens_servico(data_entrada);

DELETE FROM equipamentos WHERE id NOT IN (SELECT equipamento_id FROM ordens_servico);";

        private const string SchemaV3 = @"
CREATE TABLE IF NOT EXISTS os_itens (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    os_id INTEGER NOT NULL,
    descricao TEXT NOT NULL,
    quantidade INTEGER NOT NULL DEFAULT 1,
    FOREIGN KEY (os_id) REFERENCES ordens_servico(id) ON DELETE CASCADE
);

CREATE INDEX IF NOT EXISTS idx_itens_os ON os_itens(os_id);";
    }
}