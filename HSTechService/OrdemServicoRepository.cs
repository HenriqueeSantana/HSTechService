using Microsoft.Data.Sqlite;

namespace HSTechService
{
    public static class OrdemServicoRepository
    {
        private const string SelectBase = @"
SELECT o.id, o.cliente_id, o.equipamento_id, c.nome, c.telefone, c.whatsapp,
       o.data_entrada, o.data_entrega, o.status, o.defeito_relatado, o.laudo, o.valor,
       e.tipo, e.marca, e.modelo, e.numero_serie, e.senha, e.processador, e.memoria,
       e.armazenamento, e.acessorios, e.observacoes,
       c.cpf_cnpj, c.endereco, c.numero, c.bairro, c.cidade
FROM ordens_servico o
JOIN clientes c ON c.id = o.cliente_id
JOIN equipamentos e ON e.id = o.equipamento_id";

        public static int Criar(int clienteId, Equipamento eq, string defeito)
        {
            using var con = Database.Abrir();
            using var tx = con.BeginTransaction();

            long equipamentoId;
            using (var cmd = con.CreateCommand())
            {
                cmd.Transaction = tx;
                cmd.CommandText = @"
INSERT INTO equipamentos
    (cliente_id, tipo, marca, modelo, numero_serie, senha, processador, memoria, armazenamento, acessorios, observacoes)
VALUES
    (@cliente, @tipo, @marca, @modelo, @serie, @senha, @processador, @memoria, @armazenamento, @acessorios, @obs)";
                cmd.Parameters.AddWithValue("@cliente", clienteId);
                cmd.Parameters.AddWithValue("@tipo", eq.Tipo);
                cmd.Parameters.AddWithValue("@marca", eq.Marca);
                cmd.Parameters.AddWithValue("@modelo", eq.Modelo);
                cmd.Parameters.AddWithValue("@serie", eq.NumeroSerie);
                cmd.Parameters.AddWithValue("@senha", eq.Senha);
                cmd.Parameters.AddWithValue("@processador", eq.Processador);
                cmd.Parameters.AddWithValue("@memoria", eq.Memoria);
                cmd.Parameters.AddWithValue("@armazenamento", eq.Armazenamento);
                cmd.Parameters.AddWithValue("@acessorios", eq.Acessorios);
                cmd.Parameters.AddWithValue("@obs", eq.Observacoes);
                cmd.ExecuteNonQuery();
                equipamentoId = UltimoId(con, tx);
            }

            long osId;
            using (var cmd = con.CreateCommand())
            {
                cmd.Transaction = tx;
                cmd.CommandText = @"
INSERT INTO ordens_servico (cliente_id, equipamento_id, data_entrada, status, defeito_relatado)
VALUES (@cliente, @equipamento, @data, 'Aguardando', @defeito)";
                cmd.Parameters.AddWithValue("@cliente", clienteId);
                cmd.Parameters.AddWithValue("@equipamento", equipamentoId);
                cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@defeito", defeito);
                cmd.ExecuteNonQuery();
                osId = UltimoId(con, tx);
            }

            tx.Commit();
            return (int)osId;
        }

        public static List<OrdemServico> Listar(string busca, string status)
        {
            var lista = new List<OrdemServico>();

            string numero = busca.TrimStart('0');
            if (numero.Length == 0)
                numero = busca;

            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = SelectBase + @"
WHERE (@status = 'Todos' OR o.status = @status)
  AND (CAST(o.id AS TEXT) LIKE @numero
       OR c.nome LIKE @busca
       OR e.marca LIKE @busca
       OR e.modelo LIKE @busca
       OR e.numero_serie LIKE @busca
       OR o.defeito_relatado LIKE @busca)
ORDER BY o.id DESC";
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@numero", "%" + numero + "%");
            cmd.Parameters.AddWithValue("@busca", "%" + busca + "%");

            using var r = cmd.ExecuteReader();
            while (r.Read())
                lista.Add(Mapear(r));

            return lista;
        }

        public static List<OrdemServico> ListarPorCliente(int clienteId)
        {
            var lista = new List<OrdemServico>();

            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = SelectBase + @"
WHERE o.cliente_id = @cliente
ORDER BY o.id DESC";
            cmd.Parameters.AddWithValue("@cliente", clienteId);

            using var r = cmd.ExecuteReader();
            while (r.Read())
                lista.Add(Mapear(r));

            return lista;
        }

        public static List<OrdemServico> ListarEntreguesNoPeriodo(string inicio, string fim)
        {
            var lista = new List<OrdemServico>();

            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = SelectBase + @"
WHERE o.data_entrega IS NOT NULL AND o.data_entrega >= @ini AND o.data_entrega < @fim
ORDER BY o.data_entrega";
            cmd.Parameters.AddWithValue("@ini", inicio);
            cmd.Parameters.AddWithValue("@fim", fim);

            using var r = cmd.ExecuteReader();
            while (r.Read())
                lista.Add(Mapear(r));

            return lista;
        }

        public static OrdemServico? BuscarPorId(int osId)
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = SelectBase + " WHERE o.id = @id";
            cmd.Parameters.AddWithValue("@id", osId);

            using var r = cmd.ExecuteReader();
            return r.Read() ? Mapear(r) : null;
        }

        public static void Atualizar(int osId, string status, string laudo, double valor)
        {
            using var con = Database.Abrir();
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
UPDATE ordens_servico SET
    status = @status,
    laudo = @laudo,
    valor = @valor,
    data_entrega = CASE WHEN @status = 'Entregue'
                        THEN COALESCE(data_entrega, @agora)
                        ELSE NULL END
WHERE id = @id";
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@laudo", laudo);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@agora", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@id", osId);
            cmd.ExecuteNonQuery();
        }

        public static void Excluir(int osId, int equipamentoId)
        {
            using var con = Database.Abrir();
            using var tx = con.BeginTransaction();

            using (var cmd = con.CreateCommand())
            {
                cmd.Transaction = tx;
                cmd.CommandText = "DELETE FROM ordens_servico WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", osId);
                cmd.ExecuteNonQuery();
            }

            using (var cmd = con.CreateCommand())
            {
                cmd.Transaction = tx;
                cmd.CommandText = "DELETE FROM equipamentos WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", equipamentoId);
                cmd.ExecuteNonQuery();
            }

            tx.Commit();
        }

        private static OrdemServico Mapear(SqliteDataReader r)
        {
            return new OrdemServico
            {
                Id = r.GetInt32(0),
                ClienteId = r.GetInt32(1),
                EquipamentoId = r.GetInt32(2),
                ClienteNome = Texto(r, 3),
                Telefone = Texto(r, 4),
                WhatsApp = Texto(r, 5),
                DataEntrada = Texto(r, 6),
                DataEntrega = Texto(r, 7),
                Status = Texto(r, 8),
                DefeitoRelatado = Texto(r, 9),
                Laudo = Texto(r, 10),
                Valor = r.IsDBNull(11) ? 0 : r.GetDouble(11),
                Tipo = Texto(r, 12),
                Marca = Texto(r, 13),
                Modelo = Texto(r, 14),
                NumeroSerie = Texto(r, 15),
                Senha = Texto(r, 16),
                Processador = Texto(r, 17),
                Memoria = Texto(r, 18),
                Armazenamento = Texto(r, 19),
                Acessorios = Texto(r, 20),
                Observacoes = Texto(r, 21),
                CpfCnpj = Texto(r, 22),
                Endereco = Texto(r, 23),
                NumeroEndereco = Texto(r, 24),
                Bairro = Texto(r, 25),
                Cidade = Texto(r, 26)
            };
        }

        private static long UltimoId(SqliteConnection con, SqliteTransaction tx)
        {
            using var cmd = con.CreateCommand();
            cmd.Transaction = tx;
            cmd.CommandText = "SELECT last_insert_rowid()";
            return Convert.ToInt64(cmd.ExecuteScalar());
        }

        private static string Texto(SqliteDataReader r, int indice)
        {
            return r.IsDBNull(indice) ? "" : r.GetString(indice);
        }
    }
}