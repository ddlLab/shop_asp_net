using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace testproj
{
    class Program
    {
        static void SelectSample()
        {
            SqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                SelectAllUsers test = new SelectAllUsers(connection);
                test.Execute();
                Console.WriteLine(string.Join("\n", test.users));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Закрыть соединение.
                connection.Close();
                // Разрушить объект, освободить ресурс.
                connection.Dispose();
            }
            Console.Read();
        }

        static void InsertSample()
        {
            SqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                QueryBase test = new InsertUser("Ivan", "nonstop@er.cd", "qwertt", connection);
                test.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
            
        }

        static void Main(string[] args)
        {
            SelectSample();
         //   SendAuthCode("sasha.agratina@gmail.com", "123456");
        }

        public static  bool SendAuthCode(string email, string code)
        {
            try
            {

                MailAddress from = new MailAddress("just.for.fun.that.s.it.tralala@gmail.com", "ShelterInfo");
                MailAddress to = new MailAddress(email);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "AuthCode";
                m.Body = code;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("just.for.fun.that.s.it.tralala@gmail.com", "girlyvewsjletabt");
                smtp.EnableSsl = true;
                smtp.Send(m);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        private static void QueryEmployee(SqlConnection conn)
        {
         //   string sql = "Select * FROM user_info";
         //
         //   // Создать объект Command.
         //   SqlCommand cmd = new SqlCommand();
         //
         //   // Сочетать Command с Connection.
         //   cmd.Connection = conn;
         //   cmd.CommandText = sql;
         //
         //
         //   using (DbDataReader reader = cmd.ExecuteReader())
         //   {
         //       if (reader.HasRows)
         //       {
         //
         //           while (reader.Read())
         //           {
         //               // Индекс столбца Emp_ID в команде SQL.
         //               
         //               long    
         //               string  
         //               string  
         //               string  
         //
         //
         //               Console.WriteLine("--------------------");
         //               Console.WriteLine($"userId: {userId}" );
         //               Console.WriteLine($"login:  {login }" );
         //               Console.WriteLine($"email:  {email }" );
         //               Console.WriteLine($"pass:   {pass  }");
         //           }
         //       }
         //   }

        }



    }
}
