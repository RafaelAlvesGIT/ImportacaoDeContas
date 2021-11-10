using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContas.Util
{
    public class ManipularArquivo
    {
        private OleDbConnection oledbConn;
        private OleDbCommand cmd;
        private OleDbDataReader reader;
        public OleDbDataReader AbrirArquivo(string connectionString, string NomeAbaPlanilha)
        {
            oledbConn = new OleDbConnection(connectionString);
            oledbConn.Open();
            DataTable dt = new DataTable();

            using (cmd = new OleDbCommand("SELECT * FROM ["+NomeAbaPlanilha+"$]", oledbConn))
            {
                reader = cmd.ExecuteReader();
            }

            return reader;
        }
    }
}
