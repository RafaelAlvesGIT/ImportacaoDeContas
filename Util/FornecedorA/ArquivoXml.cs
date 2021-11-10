using ControleDeContas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ControleDeContas.Util.FornecedorA
{
    public class ArquivoXml : IConta
    {
        public void ImportacaoArquivo()
        {
            Conta conta = new Conta();
            try
            {
                using (XmlReader reader = XmlReader.Create(Diretorio.ArquivoXml))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            if (reader.Name.ToString() == "Conta")
                            {
                                conta = new Conta();
                            }

                            switch (reader.Name.ToString())
                            {
                                case "Nome":
                                    conta.Nome = reader.ReadString();
                                    break;
                                case "Valor":
                                    conta.Valor = reader.ReadString();
                                    break;
                                case "TipoConta":
                                    conta.TipoConta = reader.ReadString();
                                    break;
                                case "DataValidade":
                                    conta.DataVencimento = Convert.ToDateTime(reader.ReadString());
                                    break;
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
               var Erro = ex.Message;
            }
        }
    }
}
