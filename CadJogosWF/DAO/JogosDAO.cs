using CadJogosWF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadJogosWF.DAO
{
    public class JogosDAO
    {
        private SqlParameter[] CriaParametros(JogosViewModel jogos)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@ID", jogos.ID);
            p[1] = new SqlParameter("@Name", jogos.Name);
            p[2] = new SqlParameter("@Valor", jogos.Valor);
            p[3] = new SqlParameter("@Data", jogos.Data);
            p[4] = new SqlParameter("@IdCategoria", jogos.IDCategoria);
            return p;
        }

        public void Inserir(JogosViewModel jogos)
        {
            SqlParameter[] p = CriaParametros(jogos);

            string sql = "set dateformat dmy; " +
            "insert into jogos(ID, Name, Valor, Data, IdCategoria)" +
            "Values (@ID, @Name, @Valor, @Data, @IdCategoria)";

            HelperDAO.ExecutaSQL(sql, p);
        }

        public void Alterar(JogosViewModel jogos)
        {
            string sql = "set dateformat dmy;" + 
            "update jogos set name = @Name, "+
            "valor = @Valor, " +
            "Data = @Data, " +
            "IdCategoria = @IdCategoria where ID = @ID";
            HelperDAO.ExecutaSQL(sql,CriaParametros(jogos));
        }

        public void Deletar(int Id)
        {
            string sql = "delete jogos where Id = @Id";
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Id", Id);
            HelperDAO.ExecutaSQL(sql, p);
        }
        public JogosViewModel Consulta(int Id)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("ID", Id);

            string sql = "select * from jogos where ID = @ID";
            using (DataTable tabela = HelperDAO.ExecutaSelect(sql, p))
            {
                if (tabela.Rows.Count == 0)
                    return null;
                else
                    return MontaModel(tabela.Rows[0]);
            }
        }


        public List<JogosViewModel> Listagem()
        {
            string sql = "select * from jogos order by nome";
            using (DataTable tabela = HelperDAO.ExecutaSelect(sql, null))
            {
                List<JogosViewModel> lista = new List<JogosViewModel>();
                foreach (DataRow registro in tabela.Rows)
                    lista.Add(MontaModel(registro));

                return lista;
            }
        }

        public JogosViewModel MontaModel(DataRow registro)
        {

            JogosViewModel jogos = new JogosViewModel();

             jogos.ID = Convert.ToInt32(registro["id"]);
             jogos.Name = registro["nome"].ToString();
             jogos.Valor = Convert.ToInt32(registro["valor"]);
             jogos.Data = Convert.ToDateTime(registro["DataNascimento"]);
             jogos.IDCategoria = Convert.ToInt32(registro["IdCategoria"]);
             

            return jogos;
        }
    }
}
