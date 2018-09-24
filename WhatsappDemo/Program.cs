using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppApi;

namespace WhatsappDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string Message = "Hi there, Sample test message sent.";
            SendMessage("917709981177", Message);
            Console.ReadLine();

        }

        private static string SendMessage(String To, String Message)
        {
            string status = string.Empty;
            WhatsApp wa = new WhatsApp("917709981177", "352038068257991", "Amit", false, false);
            wa.OnConnectSuccess += () =>
            {
                wa.OnLoginSuccess += (phonenumber, data) =>
                {
                    status = "Connection Success";
                    wa.SendMessage(To, Message);
                    status = "Message sent Success";
                };

                wa.OnLoginFailed += (data) =>
                {
                    status = "Login Failed" + data;
                };
                wa.Login();
            };
            wa.OnConnectFailed += (ex) =>
            {
                status = "Connection Failed" + ex.StackTrace;
            };
            wa.Connect();

            return status;
        }
    }
}
