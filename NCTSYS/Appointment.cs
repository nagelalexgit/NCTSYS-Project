using Oracle.ManagedDataAccess.Client;
using System;



namespace NCTSYS
{
    class Appointment
    {
        //instance variables
        private int app_id;
        private string app_time;
        private string app_date;
        private char app_status = 'A';
        private string reg_no;
        private int centre_id;
        private string unique_app_id;

        public Appointment()
        {
            app_id = 0;
            app_time = "";
            app_date = "";
            app_status = ' ';
            reg_no = "";
            centre_id = 0;
        }
        public Appointment(int app_id, String app_time, String app_date, char app_status, String reg_no, int centre_id, String unique_app_id)
        {
            this.app_id = app_id;
            this.app_time = app_time;
            this.app_date = app_date;
            this.app_status = app_status;
            this.reg_no = reg_no; 
            this.centre_id = centre_id;
            this.unique_app_id = unique_app_id;
        }
        public int getAppID()
        {
            return app_id;
        }
        public String getAppTime()
        {
            return app_time;
        }
        public String getAppDate()
        {
            return app_date;
        }
        public Char getAppStatus()
        {
            return app_status;
        }
        public String getRegNo()
        {
            return reg_no;
        }
        public int getCentreID()
        {
            return centre_id;
        }
        public String getUniqueAppID()
        {
            return unique_app_id;
        }
        public static int nextAppID()
        {
            int nextID;
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "SELECT MAX(APP_ID) FROM APPOINTMENTS";
            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();

            dr.Read();

            if (dr.IsDBNull(0))
            {
                nextID = 1;
            }
            else
            {
                nextID = dr.GetInt32(0) + 1;
            }

            myConn.Close();

            return nextID;
        }

        public void bookAppointment()
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "INSERT INTO APPOINTMENTS VALUES(" + this.app_id + ",'" + this.app_time + "','" + this.app_date + "','" + this.app_status + "','" + this.reg_no + "'," + this.centre_id + ", '" + unique_app_id + "')";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);
            cmd.ExecuteNonQuery();

            //Close DB
            myConn.Close();
        }
        public void updateAppointment()
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "UPDATE APPOINTMENTS SET APP_STATUS = 'B', REG_NO = '" + this.reg_no + "', UNIQUEAPPID = '" + this.unique_app_id + "' WHERE CENTRE_ID = " + this.centre_id + " AND APP_TIME = '" + this.app_time + "' AND APP_DATE = '" + this.app_date + "'";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);
            cmd.ExecuteNonQuery();

            //Close DB
            myConn.Close();
        }
        public void getAppointmentDetails(string appID)
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "SELECT * FROM APPOINTMENTS WHERE UNIQUEAPPID = '" + appID + "'";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                this.app_id = dr.GetInt32(0);
                this.app_time = dr.GetString(1);
                this.app_date = dr.GetDateTime(2).ToString();
                this.app_status = Convert.ToChar(dr.GetString(3).Substring(0,1));
                this.reg_no = dr.GetString(4);
                this.centre_id = dr.GetInt32(5);
                this.unique_app_id = dr.GetString(6);
            }
            // close DB
            myConn.Close();
        }
        public static String isExists(String AppID)
        {
            String answer;
            String status;

            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "SELECT * FROM APPOINTMENTS WHERE UNIQUEAPPID = '" + AppID + "'";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                status = dr.GetString(3).Trim();
                if (status == "C")
                {
                    answer = "canceled";// canceled 
                }
                else
                {
                    answer = "booked";//ready for cancel
                }
            }
            else
            {
                answer = "non";// Appointment not found
            }

            //Close DB
            myConn.Close();
            return answer;
        }
        public static void cancelAppointment(string appID)
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "DELETE FROM APPOINTMENTS WHERE UNIQUEAPPID = '" + appID + "'";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);
            cmd.ExecuteNonQuery();

            //Close DB
            myConn.Close();
        }

        public static void setNotAttended(string appID)
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "UPDATE APPOINTMENTS SET APP_STATUS = 'N' WHERE UNIQUEAPPID = '" + appID + "'";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);
            cmd.ExecuteNonQuery();

            //Close DB
            myConn.Close();
        }
        public static void setAsProcessed(string appID)
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "UPDATE APPOINTMENTS SET APP_STATUS = 'P' WHERE UNIQUEAPPID = '" + appID + "'";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);
            cmd.ExecuteNonQuery();

            //Close DB
            myConn.Close();
        }

    }
}
