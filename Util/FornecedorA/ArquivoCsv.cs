using ControleDeContas.Dao;
using ControleDeContas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContas.Util.FornecedorA
{
    public class ArquivoCsv : IConta
    {
        private ContaDao Dao;
        public ArquivoCsv()
        {
            Dao = new ContaDao();
        }
        public void ImportacaoArquivo()
        {
            try
            {
                var NomeArquivo = Diretorio.ArquivoCsv;
                Csv csv = new Csv();
                StreamReader reader = csv.AbrirArquivo(NomeArquivo);
                List<String> ListaDadosCsv = csv.LerArquivo(reader);
                List<Conta> ListaConta = MontarListaObjeto(ListaDadosCsv);

                Dao.InserirListaConta(ListaConta);
            }catch(Exception ex)
            {
                var Erro = ex.Message;
            }
        }

      public List<Conta> MontarListaObjeto(List<String> Linhas)
        {
            List<Conta> Lista = new List<Conta>();

            for(int i = 0; i < Linhas.Count; i++)
            {
                string[] valoresLinha = Linhas[i].Split(";");
                if (valoresLinha.Length > 0)
                {
                    Conta Conta = new Conta();
                    Conta.Nome = valoresLinha[0].ToString();
                    Conta.TipoConta = valoresLinha[1].ToString();
                    Conta.Valor = valoresLinha[2].ToString();
                    Conta.DataVencimento = Convert.ToDateTime(valoresLinha[3]);
                    Lista.Add(Conta);
                }
            }

            return Lista;
        }
    }
}
