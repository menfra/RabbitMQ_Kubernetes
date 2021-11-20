using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Env
{
    public static class Util
    {
        public const string SPNUserName = "Some5trongN@me";
        public const string PassWord = "5ecureP@55";
        public static string ConnectionString = "mongodb+srv://cashsample:P%2355w0rd@cashsample.wzori.mongodb.net/cashsample?retryWrites=true&w=majority";
        public static string Port;
        public static string AuthMechanism;
        public static string DBName;
        public static string UserName;
        public static int MongoPort;
        public static string MongoServer;
        public static string PasswordEvidence;
       

        public static void GetEnvironmentValues()
        {
            AuthMechanism = "SCRAM-SHA-1";
            DBName = "";
            UserName = "";
            MongoPort = 2;
            MongoServer = "";
            PasswordEvidence = ""; // must be encrypted
            Port = "";
        }
    }
}
