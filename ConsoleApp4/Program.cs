using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VegetablesAndFruits
{
    class Program
    {
        static SqlConnection conn = null;
        static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=FruitsAndVegetables;Trusted_Connection=True;";

        static void ConnectToDatabase()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Уже подключены к базе данных.");
                return;
            }

            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                Console.WriteLine("Подключение успешно установлено к базе данных «Овощи и фрукты».");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Не удалось подключиться к базе данных: " + ex.Message);
                conn = null;
            }
        }

        static void DisconnectFromDatabase()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Подключение закрыто.");
            }
            else
            {
                Console.WriteLine("Нет активного подключения к базе данных.");
            }
        }
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Введите команду:");
                Console.WriteLine("1 - Подключиться к базе данных");
                Console.WriteLine("2 - Отключиться от базы данных");
                Console.WriteLine("0 - Выйти");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ConnectToDatabase();
                        break;
                    case "2":
                        DisconnectFromDatabase();
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Неверная команда. Попробуйте снова.");
                        break;
                }
            }
        }

       
    }
}