﻿using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace FinalProject_v1
{
    class DatabaseConnect
    {

        //Connection string
        public static string BuildConnectionString()
        {
            string serverIP = "";
            string port = "";

            try
            {
                using (StreamReader sr = new StreamReader(@"C:\VFW\connect.txt"))
                {
                    serverIP = sr.ReadLine();
                    port = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return $"server={serverIP};uid=dbsAdmin;pwd=password;database=RecipeFinder;SslMode=none;port={port};";
        }

        //Connection to database
        public static MySqlConnection Connect(string myConnString)
        {
            MySqlConnection conn = new MySqlConnection();

            try
            {
                conn.ConnectionString = myConnString;
                conn.Open();
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show($"Can't resolve host address.\r\n\r\n{myConnString}"); break;
                    case 1045: MessageBox.Show($"Invaild name/password"); break;
                    default: MessageBox.Show($"{e.ToString()}\r\n\r\n{myConnString}"); break;
                }
            }
            return conn;
        }

    }
}
