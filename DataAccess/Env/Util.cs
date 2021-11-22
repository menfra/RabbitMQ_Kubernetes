using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Env
{
    public static class Util
    {
        public static string MongoConnectionString = "mongodb+srv://cashsample:P%2355w0rd@cashsample.wzori.mongodb.net/cashsample?retryWrites=true&w=majority";
        //public static string PostgresConnectionString = $"Host=localhost;Database=cashsample;Username=postgres;Password=postgres";

        public static string PostgresConnectionString = $"" +
            $"User ID=vawaumqrgszrsb;" +
            $"Password=ff9eebc84633299e3b7c4eefd47af84c97130c02147b91ea1216302677f392f3;" +
            $"Host=ec2-54-228-99-58.eu-west-1.compute.amazonaws.com;" +
            $"Port=5432;" +
            $"Database=d638oav37cno5j;" +
            $"Pooling=true;SSL Mode=Require;TrustServerCertificate=True;";



        //public static void GetEnvironmentValues()
        //{
        //    //MongoConnectionString = "";
        //    //PostgresConnectionString = "";
        //}
    }
}
