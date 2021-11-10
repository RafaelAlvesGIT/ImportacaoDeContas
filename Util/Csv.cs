using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContas.Util
{
    public class Csv
    {
        public StreamReader AbrirArquivo(string CaminhoArquivo)
        {
            DataTable dt = new DataTable();
            StreamReader sr = new StreamReader(CaminhoArquivo);
            
            return sr;
        }

        public List<String> LerArquivo(StreamReader sr)
        {
            string[] headers = sr.ReadLine().Split(',');
            List<String> Lista = new List<String>();
           
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                for(int i = 0; i < rows.Length; i++)
                {
                    Lista.Add(rows[i].ToString());
                }
            }

            return Lista;
        }
    }
}
