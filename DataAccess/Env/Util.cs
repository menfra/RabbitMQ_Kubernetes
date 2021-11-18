using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Env
{
    public static class Util
    {
        public const string SPNUserName = "Some5trongN@me";
        public const string PassWord = "5ecureP#55";
        public static string ConnectionString;
        public static string Port;
        public static string AuthMechanism;
        public static string DBName;
        public static string UserName;
        public static int MongoPort;
        public static string MongoServer;
        public static string PasswordEvidence;
        public static string PluginTempFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PluginTemp\";
       

        public static void GetEnvironmentValues()
        {
            //AuthMechanism = ConfigurationManager.AppSettings["mongoAuthMechanism"];
            //DBName = ConfigurationManager.AppSettings["mongoDBName"];
            //UserName = ConfigurationManager.AppSettings["mongoUserName"];
            //MongoPort = Convert.ToInt32(ConfigurationManager.AppSettings["mongoPort"]);
            //MongoServer = ConfigurationManager.AppSettings["MongoServer"];
            //PasswordEvidence = EncryptionProvider.GetInstance.DecryptFromBase64String(ConfigurationManager.AppSettings["mongoPasswordEvidence"]);
            //Port = ConfigurationManager.AppSettings["port"];
        }
    }
}
