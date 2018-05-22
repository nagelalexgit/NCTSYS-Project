using Oracle.ManagedDataAccess.Client;
using System;

namespace NCTSYS
{
    class Test
    {
        //instance variables
        private int test_id;
        private string reg_no;
        private int centre_id;
        private string date;
        private int front_axle;
        private int rear_axle;
        private int brake;
        private int parking;

        public Test()
        {
            test_id = 0;
            reg_no = "";
            centre_id = 0;
            date = "";
            front_axle = 0;
            rear_axle = 0;
            brake = 0;
            parking = 0;
        }
        public Test(int TestID, String RegNo, int CenreID, String Date, int FrontAxle, int RearAxle, int Brake, int Parking)
        { 
            test_id = TestID;
            reg_no = RegNo;
            centre_id = CenreID;
            date = Date;
            front_axle = FrontAxle;
            rear_axle = RearAxle;
            brake = Brake;
            parking = Parking;
        }
        public int getTestId() { return test_id; }
        public String getTRegNo() { return reg_no; }
        public int getCentreID() { return centre_id; }
        public String getDate() { return date; }
        public int getFrontAxle() { return front_axle; }
        public int getRearAxle() { return rear_axle; }
        public int getBrake() { return brake; }
        public int getParking() { return parking; }

        internal void recordTestResults()
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "INSERT INTO TESTS VALUES(" + this.test_id + ",'" + this.reg_no + "'," + this.centre_id + ",'" + this.date + "'," + this.front_axle + "," + this.rear_axle + "," + this.brake + "," + this.parking + ")";
            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);
            cmd.ExecuteNonQuery();

            //Close DB
            myConn.Close();
        }
    }
}
