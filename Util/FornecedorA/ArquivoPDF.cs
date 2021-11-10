using ControleDeContas.Dao;
using ControleDeContas.Models;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ControleDeContas.Util.FornecedorA
{
    public class ArquivoPDF : IConta
    {
        private ContaDao dao;
        private Conta conta;
        public  ArquivoPDF()
        {
            dao = new ContaDao();
            conta = new Conta();
        }
        public void ImportacaoArquivo()
        {
            PdfReader reader = new PdfReader(Diretorio.ArquivoPdf);
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
            }
            
            reader.Close();
           
            String[] Valores = text.Split("\n");
            for(var i = 0; i < Valores.Length; i++)
            {
                if(Valores.GetValue(i).ToString().Contains("Nome"))
                {
                    conta.Nome = Valores.GetValue(i).ToString();
                }
                if (Valores.GetValue(i).ToString().Contains("Valor"))
                {
                    conta.Valor = Valores.GetValue(i).ToString();
                }
                if (Valores.GetValue(i).ToString().Contains("Tipo"))
                {
                    conta.TipoConta = Valores.GetValue(i).ToString();
                }
                if (Valores.GetValue(i).ToString().Contains("Data Vencimento"))
                {
                    conta.DataVencimento = Convert.ToDateTime(Valores.GetValue(i).ToString());
                }
            };

            if (Valores.Length > 0)
            {
                dao.Inserir(conta);
            }
        }
    }
}
