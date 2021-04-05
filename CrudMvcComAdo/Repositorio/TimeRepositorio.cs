using CrudMvcComAdo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudMvcComAdo.Repositorio
{
    public class TimeRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            _con = new SqlConnection(constr);
        }

        //Adicionar time

        public bool AdicionarTime(Times timeObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirTime", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Time", timeObj.Time);
                command.Parameters.AddWithValue("@EstadoId", timeObj.EstadoId);
                command.Parameters.AddWithValue("@Cores", timeObj.Cores);

                _con.Open();

               i = command.ExecuteNonQuery();
         
            }

            _con.Close();

            return i >= 1;
        }

        //Obter todos os times

        public List<Times> ObterTimes()
        {
            Connection();
            List<Times> TimesList = new List<Times>();

            using (SqlCommand command = new SqlCommand("ObterTimes", _con))
            {
                command.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Times time = new Times()
                    {
                        TimesId = Convert.ToInt32(reader["TimeId"]),
                        Time = Convert.ToString(reader["Time"]),
                        EstadoId = Convert.ToInt32(reader["EstadoId"]),
                        EstadoSigla = Convert.ToString(reader["EstadoSigla"]),
                        Cores = Convert.ToString(reader["Cores"])
                    };

                    TimesList.Add(time);
                }

                _con.Close();

                return TimesList;
            }
        }


        //Atualizar Time
        public bool AtualizarTime(Times timeObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarTime", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TimeId", timeObj.TimesId);
                command.Parameters.AddWithValue("@Time", timeObj.Time);
                command.Parameters.AddWithValue("@EstadoId", timeObj.EstadoId);
                command.Parameters.AddWithValue("@Cores", timeObj.Cores);

                _con.Open();

                i = command.ExecuteNonQuery();

            }

            _con.Close();

            return i >= 1;
        }

        public bool ExcluirTime(int id)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirTime", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TimeId", id);
               
                _con.Open();

                i = command.ExecuteNonQuery();

            }

            _con.Close();

            if (i >= 1)
            {
                return true;
            }

            return false;
        }

        public List<Times> ObterEstados()
        {
            Connection();
            List<Times> EstadoList = new List<Times>();

            using (SqlCommand command = new SqlCommand("ObterEstados", _con))
            {
                command.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Times time = new Times()
                    {
                        EstadoId = Convert.ToInt32(reader["EstadoId"]),
                        EstadoSigla = Convert.ToString(reader["EstadoNome"])
                    };

                    EstadoList.Add(time);
                }

                _con.Close();

                return EstadoList;
            }
        }
    }
}