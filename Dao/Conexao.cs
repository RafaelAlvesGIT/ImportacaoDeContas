using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContas.Dao
{
    public class Conexao
    {
        private string ConectionString = "";
        public Conexao()
        {
            ConectionString = "Password=teste;Persist Security Info=True;User ID=Usuario;Initial Catalog=Gasto;Data Source=DESKTOP-H22222";
        }

        public System.Data.IDbConnection ConexaoBanco()
        {
            return new SqlConnection(ConectionString);
        }
    }
}
