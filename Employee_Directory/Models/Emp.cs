using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Employee_Directory.Models
{
    public class Emp
    {
        public class Details_Param

        {
            public string Emp_ID { get; set; }
            
        }
        public class Details_Paramss

        {
            public string Location { get; set; }

        }
        public class Status1
      
        {
            public string Emp_ID { get; set; }
            public string Emp_Name { get; set; }
            public string Emp_Address { get; set; }
            public string Emp_Desg { get; set; }
            public string Emp_totalExp { get; set; }
            public string Emp_InHouse_Exp { get; set; }
            public string Emp_Team { get; set; }
            public string Emp_Rp_Manager { get; set; }
            public string Emp_Days_Present { get; set; }
            public string Emp_Casucal { get; set; }
            public string Emp_Silck { get; set; }
            public string Emp_Date { get; set; }
            public string Emp_Leave_Type { get; set; }
            public string Emp_Count { get; set; }
            public string Emp_Status { get; set; }
            public string Emp_Probation { get; set; }
            public string Emp_Message { get; set; }
            public string Emp_Acessable { get; set; }
            public string Emp_Payable { get; set; }
            public string Emp_Dep { get; set; }
            public string Emp_ImageURL { get; set; }


        }

        public class Loc

        {
            public string Name { get; set; }
            public string ID { get; set; }
        }

            private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["StudentConn"].ToString();
            con = new SqlConnection(constring);

        }

        public List<Status1> Emp_Details(Details_Param U)
        {
            List<Status1> resultList = new List<Status1>();

            connection();
            using (SqlCommand Cmd = new SqlCommand("Emp_Details", con))
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@Emp_ID", U.Emp_ID);
                con.Open();
                using (SqlDataReader reader = Cmd.ExecuteReader())
                {
                    
                    while (reader.HasRows && reader.Read())
                    {
                        Status1 result = new Status1
                        {
                            Emp_ID = reader["Emp_ID"].ToString(),
                            Emp_Name = reader["Emp_Name"].ToString(),
                            Emp_Address = reader["Emp_Address"].ToString(),
                            Emp_Desg = reader["Emp_Desg"].ToString(),
                            Emp_totalExp = reader["Emp_totalExp"].ToString(),
                            Emp_InHouse_Exp = reader["Emp_InHouse_Exp"].ToString(),
                            Emp_Team = reader["Emp_Team"].ToString(),
                            Emp_Rp_Manager = reader["Emp_Rp_Manager"].ToString(),
                            Emp_Days_Present = reader["Emp_Days_Present"].ToString(),
                            Emp_Casucal = reader["Emp_Casucal"].ToString(),
                            Emp_Silck = reader["Emp_Silck"].ToString(),
                            Emp_Date = reader["Emp_Date"].ToString(),
                            Emp_Leave_Type = reader["Emp_Leave_Type"].ToString(),
                            Emp_Count = reader["Emp_Count"].ToString(),
                            Emp_Status = reader["Emp_Status"].ToString(),
                            Emp_Probation = reader["Emp_Probation"].ToString(),
                            Emp_Message = reader["Emp_Message"].ToString(),
                            Emp_Acessable = reader["Emp_Acessable"].ToString(),
                            Emp_Payable = reader["Emp_Payable"].ToString(),
                            Emp_Dep = reader["Emp_Dep"].ToString(),
                            Emp_ImageURL = reader["Emp_ImageURL"].ToString()
                        };

                        resultList.Add(result);
                    }
                }
                con.Close();
            }

            return resultList;
        }

        public List<Loc> EmpLocation()
        {
            List<Loc> resultList = new List<Loc>();

            connection();
            using (SqlCommand Cmd = new SqlCommand("Emp_Loc", con))
            {
                con.Open();
                using (SqlDataReader reader = Cmd.ExecuteReader())
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Loc result = new Loc
                        {
                            Name = reader["Name"].ToString(),
                            ID = reader["ID"].ToString(),

                        };

                        resultList.Add(result);
                    }
                }
                con.Close();
            }

            return resultList;
        }

        public List<Loc> EmpDep()
        {
            List<Loc> resultList = new List<Loc>();

            connection();
            using (SqlCommand Cmd = new SqlCommand("Emp_Dep_Sp", con))
            {
                con.Open();
                using (SqlDataReader reader = Cmd.ExecuteReader())
                {
                    while (reader.HasRows && reader.Read())
                    {
                        Loc result = new Loc
                        {
                            Name = reader["Name"].ToString(),
                            ID = reader["ID"].ToString(),

                        };

                        resultList.Add(result);
                    }
                }
                con.Close();
            }

            return resultList;
        }

        public List<Status1> Emp_DetailsCall(Details_Paramss U)
        {
            List<Status1> resultList = new List<Status1>();

            connection();
            using (SqlCommand Cmd = new SqlCommand("Fill_LocTion", con))
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@Location", U.Location);
                con.Open();
                using (SqlDataReader reader = Cmd.ExecuteReader())
                {

                    while (reader.HasRows && reader.Read())
                    {
                        Status1 result = new Status1
                        {
                            Emp_ID = reader["Emp_ID"].ToString(),
                            Emp_Name = reader["Emp_Name"].ToString(),
                            Emp_Address = reader["Emp_Address"].ToString(),
                            Emp_Desg = reader["Emp_Desg"].ToString(),
                            Emp_totalExp = reader["Emp_totalExp"].ToString(),
                            Emp_InHouse_Exp = reader["Emp_InHouse_Exp"].ToString(),
                            Emp_Team = reader["Emp_Team"].ToString(),
                            Emp_Rp_Manager = reader["Emp_Rp_Manager"].ToString(),
                            Emp_Days_Present = reader["Emp_Days_Present"].ToString(),
                            Emp_Casucal = reader["Emp_Casucal"].ToString(),
                            Emp_Silck = reader["Emp_Silck"].ToString(),
                            Emp_Date = reader["Emp_Date"].ToString(),
                            Emp_Leave_Type = reader["Emp_Leave_Type"].ToString(),
                            Emp_Count = reader["Emp_Count"].ToString(),
                            Emp_Status = reader["Emp_Status"].ToString(),
                            Emp_Probation = reader["Emp_Probation"].ToString(),
                            Emp_Message = reader["Emp_Message"].ToString(),
                            Emp_Acessable = reader["Emp_Acessable"].ToString(),
                            Emp_Payable = reader["Emp_Payable"].ToString(),
                            Emp_Dep = reader["Emp_Dep"].ToString(),
                            Emp_ImageURL = reader["Emp_ImageURL"].ToString()
                        };

                        resultList.Add(result);
                    }
                }
                con.Close();
            }

            return resultList;
        }
    }
}