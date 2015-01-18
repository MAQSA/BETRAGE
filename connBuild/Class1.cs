using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using tmp_bd;
namespace connBuild
{
    public class connbld
    {
        SqlConnection conn;
        SqlConnectionStringBuilder connStringBuilder;

        void ConnectTo()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "PLAYZZER";
            connStringBuilder.InitialCatalog = "msl";
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());

        }
        public connbld()
        {
            ConnectTo();
        }
        public List<tmp_msl> FillComboBox()
        {
            List<tmp_msl> msl_list = new List<tmp_msl>();
            try
            {
                string cmdText = "SELECT * FROM dbo.tmp_msl";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tmp_msl t = new tmp_msl();
                    t.Id = Convert.ToInt32(reader["id"].ToString());
                    t.Tmp_Numb_t = reader["tmp_numb_t"].ToString();
                    t.Tmp_Date = reader["tmp_date"].ToString();
                    t.Tmp_Type_match = reader["tmp_type_match"].ToString();
                    t.Tmp_List_team = reader["tmp_list_team"].ToString();
                    t.Tmp_Ha = reader["tmp_gen"].ToString();
                    t.Tmp_Gen = reader["tmp_ha"].ToString();
                    t.Tmp_T_vs_t = reader["tmp_t_vs_t"].ToString();
                    t.Tmp_Bet_msl = reader["tmp_bet_msl"].ToString();
                    t.Tmp_Bet_bk = reader["tmp_bet_bk"].ToString();
                    t.Tmp_Bet_gr = reader["tmp_bet_gr"].ToString();
                    t.Tmp_1bj = reader["tmp_bet_1bj"].ToString();
                    t.Tmp_Rez = reader["tmp_rez"].ToString();

                    msl_list.Add(t);

                }
                return msl_list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void Insert(tmp_msl tm)

        //public void Insert(general_bd g, tmp_msl tm)
        {
            try
            {
                /*
                //dbo.general_bd
                String cmdText = "INSERT INTO dbo.general_bd(numb_t, date, type_match, list_team, ha, gen, t_vs_t, bet_msl, bet_bk, bet_gr, bet_1bj, rez) VALUES (@numb_t, @date, @type_match, @list_team, @ha, @gen, @t_vs_t, @bet_msl, @bet_bk, @bet_gr, @bet_1bj, @rez)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@numb_t", g.Numb_t);
                cmd.Parameters.AddWithValue("@date", g.Date);
                cmd.Parameters.AddWithValue("@type_match", g.Type_match);
                cmd.Parameters.AddWithValue("@list_team", g.List_team);
                cmd.Parameters.AddWithValue("@ha", g.Ha);
                cmd.Parameters.AddWithValue("@gen", g.Gen);
                cmd.Parameters.AddWithValue("@t_vs_t", g.T_vs_t);
                cmd.Parameters.AddWithValue("@bet_msl", g.Bet_msl);
                cmd.Parameters.AddWithValue("@bet_bk", g.Bet_bk);
                cmd.Parameters.AddWithValue("@bet_gr", g.Bet_gr);
                cmd.Parameters.AddWithValue("@bet_1bj", g.Bet_1bj);
                cmd.Parameters.AddWithValue("@rez", g.Rez);*/

                //dbo.tmp_msl
                String cmdText2 = "INSERT INTO dbo.tmp_msl(tmp_numb_t, tmp_date, tmp_type_match, tmp_list_team, tmp_ha, tmp_gen, tmp_t_vs_t, tmp_bet_msl, tmp_bet_bk, tmp_bet_gr, tmp_1bj, tmp_rez) VALUES (@tmp_numb_t, @tmp_date, @tmp_type_match, @tmp_list_team, @tmp_ha, @tmp_gen, @tmp_t_vs_t, @tmp_bet_msl, @tmp_bet_bk, @tmp_bet_gr, @tmp_1bj, @tmp_rez)";
                SqlCommand cmd2 = new SqlCommand(cmdText2, conn);
                cmd2.Parameters.AddWithValue("@tmp_numb_t", tm.Tmp_Numb_t);
                cmd2.Parameters.AddWithValue("@tmp_date", tm.Tmp_Date);
                cmd2.Parameters.AddWithValue("@tmp_type_match", tm.Tmp_Type_match);
                cmd2.Parameters.AddWithValue("@tmp_list_team", tm.Tmp_List_team);
                cmd2.Parameters.AddWithValue("@tmp_ha", tm.Tmp_Ha);
                cmd2.Parameters.AddWithValue("@tmp_gen", tm.Tmp_Gen);
                cmd2.Parameters.AddWithValue("@tmp_t_vs_t", tm.Tmp_T_vs_t);
                cmd2.Parameters.AddWithValue("@tmp_bet_msl", tm.Tmp_Bet_msl);
                cmd2.Parameters.AddWithValue("@tmp_bet_bk", tm.Tmp_Bet_bk);
                cmd2.Parameters.AddWithValue("@tmp_bet_gr", tm.Tmp_Bet_gr);
                cmd2.Parameters.AddWithValue("@tmp_1bj", tm.Tmp_1bj);
                cmd2.Parameters.AddWithValue("@tmp_rez", tm.Tmp_Rez);
               
                conn.Open();
                cmd2.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

    }
}
