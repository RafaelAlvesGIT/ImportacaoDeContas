using ControleDeContas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ControleDeContas.Dao
{
    public class ContaDao
    {
        private IDbConnection Connection;

        public ContaDao()
        {
            Conexao conexao = new Conexao();
            Connection = conexao.ConexaoBanco();
        }

        public void InserirListaConta(List<Conta> Lista)
        {
            for (int i = 0; i < Lista.Count; i++)
            {
                Inserir(Lista[i]) ;
            }
        }

        public void Inserir(Conta Conta)
        {
            var Sql = "INSERT INTO Conta(Nome, DataVencimento, Valor, TipoConta) " +
                            "OUTPUT INSERTED.[Id]" +
                                  "VALUES (@Nome, @DataVencimento, @Valor, @TipoConta)";
            Connection.Open();
            Connection.Execute(Sql, Conta);

            Connection.Close();
        }
    }
}
