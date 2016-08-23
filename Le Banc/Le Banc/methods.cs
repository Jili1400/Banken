using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Configuration;
using NpgsqlTypes;
using System.Data;
using System.Diagnostics;

namespace Le_Banc
{
    public class methods
    {
        #region loggin 
        //kollar om det finns en specifik användare med detta userName och userPassword
        public static bool checkPersonnelExist(int personnelId, string username, string password)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Banken"].ConnectionString);
            int amount = 0;
            try
            {
                conn.Open();
                string sqlCheckUser = string.Empty;

                sqlCheckUser = "SELECT DISTINCT 1 AS amount FROM personnel WHERE username = :newUserName AND password = :newPassword"
                                + " AND id_personnel <> :newIdPersonnel;";

                NpgsqlCommand command = new NpgsqlCommand(@sqlCheckUser, conn);

                command.Parameters.Add(new NpgsqlParameter("newUserName", NpgsqlDbType.Varchar));
                command.Parameters["newUserName"].Value = username;
                command.Parameters.Add(new NpgsqlParameter("newPassword", NpgsqlDbType.Varchar));
                command.Parameters["newPassword"].Value = password;
                command.Parameters.Add(new NpgsqlParameter("newIdPersonnel", NpgsqlDbType.Integer));
                command.Parameters["newIdPersonnel"].Value = personnelId; 

                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    amount = (int)(dr["amount"]); //från DISTINCT 1 AS amount - finns denna kombination så ... 
                }
            }
            finally
            {
                conn.Close();
            }
            if (amount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

         //Kod från dsu_g5 - check av access
        public static int access(int idPersonnel)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Banken"].ConnectionString);
            int access = 0;
            try
            {
                conn.Open();
                string sqlAccess = string.Empty;

                sqlAccess = "SELECT access FROM personnel WHERE idPersonnel = :newIdPersonnel;";
                NpgsqlCommand command = new NpgsqlCommand(@sqlAccess, conn);

                command.Parameters.Add(new NpgsqlParameter("newIdPersonnel", NpgsqlDbType.Integer));
                command.Parameters["newIdPersonnel"].Value = idPersonnel;

                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    access = (int)(dr["access"]);
                }
            }
            finally
            {
                conn.Close();
            }
            return access;
        }


        //public static bool checkPersonnelExist(string username, string password)
        //{
        //    NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Banken"].ConnectionString);
        //    int amount = 0;
        //    try
        //    {
        //        conn.Open();
        //        string sqlCheckUser = string.Empty;

        //        //sqlCheckUser = "SELECT Count (*) FROM personnel WHERE username = :newUserName AND password = :newPassword";
        //        //NpgsqlCommand command = new NpgsqlCommand(@sqlCheckUser, conn);

        //        sqlCheckUser = "SELECT DISTINCT 1 AS amount FROM users WHERE username = :newUserName AND password = :newPassword";
        //        NpgsqlCommand command = new NpgsqlCommand(@sqlCheckUser, conn);

        //        command.Parameters.Add(new NpgsqlParameter("newUserName", NpgsqlDbType.Varchar));
        //        command.Parameters["newUserName"].Value = username;
        //        command.Parameters.Add(new NpgsqlParameter("newUserpassword", NpgsqlDbType.Varchar));
        //        command.Parameters["newUserpassword"].Value = password;

        //        NpgsqlDataReader dr = command.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            amount = (int)(dr["amount"]);
        //        }
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    if (amount > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        #endregion loggin
        #region admin

        public static List<personnel> getPersonnelList()
        {
            List<personnel> personnelList = new List<personnel>();
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Banken"].ConnectionString);
            try
            {
                conn.Open();
                string personnelsql = string.Empty;
                personnelsql = "SELECT * from personnel";
                    
 
                NpgsqlCommand command = new NpgsqlCommand(@personnelsql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    personnel newPersonnel = new personnel();
                    newPersonnel.idPersonnel = (int)(dr["id_personnel"]);
                    newPersonnel.userName = (string)(dr["username"]);
                    newPersonnel.userPassword = (string)(dr["password"]);
                    newPersonnel.firstName = (string)(dr["firstname"]);
                    newPersonnel.lastName = (string)(dr["lastname"]);
                    newPersonnel.address = (string)(dr["address"]);
                    newPersonnel.postalCode = (string)(dr["postalcode"]);
                    newPersonnel.city = (string)(dr["city"]);
                    newPersonnel.access = (int)(dr["access"]); 
                    personnelList.Add(newPersonnel);
                }
            }
            finally
            {
                conn.Close();
            }
            return personnelList;
        }


 

        public static DataTable getResultsForPersonnel(int idPersonnel)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Banken"].ConnectionString);

            string sqlResultat = string.Empty;
            DataTable dt = new DataTable();

           //kolla denna sqlResultat så fort databas fungerar
            try
            {

                sqlResultat = "Select date AS datum, licenstest AS Licenstest, aku AS ÅKU" +
                "result AS Resultat, passed AS Godkänd FROM result WHERE result.id_personnel =  " + idPersonnel + " ";


                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlResultat, conn);
                da.Fill(dt);
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        #endregion

    }
}