using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeContas.Dao;
using ControleDeContas.Models;
namespace ControleDeContas.Util.FornecedorA
{
    public class ArquivoXLS : IConta
    {
        private ManipularArquivo arquivo;
        private OleDbDataReader reader;
        private Conta conta;
        private ContaDao contaDao;
        public ArquivoXLS()
        {
            arquivo = new ManipularArquivo();
            conta = new Conta();
            contaDao = new ContaDao();
        }

        public void ImportacaoArquivo()
        {
            var NomeArquivo = Diretorio.ArquivoXls;
            var Connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + NomeArquivo + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
          
             reader = arquivo.AbrirArquivo(Connection, "Contas1");
             if(reader != null)
             {
                List<Conta> listaContas = new List<Conta>();
                while(reader.Read())
                {
                    conta.Nome = reader.GetValue(0).ToString();
                    conta.TipoConta = reader.GetValue(1).ToString();
                    conta.Valor = reader.GetValue(2).ToString();
                    conta.DataVencimento = Convert.ToDateTime(reader.GetValue(3).ToString());
                    listaContas.Add(conta);
                }
             }
        }
    }
}
