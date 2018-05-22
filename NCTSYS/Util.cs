using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace NCTSYS
{
    class Util
    {
        //Email Validation
        public static Boolean isValidEmail(string email)
        {
            if (Regex.IsMatch(email,
                           @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //PPSN Validation
        public static Boolean isValidPPSN(String ppsn)
        {
            Regex pattern = new Regex(@"^\d{7}[A-Z]{1,2}$");

            if (pattern.IsMatch(ppsn))
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        //isNumeric Validation
        public static Boolean isNumeric(String num)
        {
            if (Regex.IsMatch(num, @"^\d+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Reg No Validation
        public static Boolean isValidReg(String regNo)
        {
            // Define Regex for car reg with 3 digits-two letters-up to 5 digits
            if ((Regex.IsMatch(regNo, "^[0-9]{2}[12][-][A-Za-z]{1,2}[-][0-9]{1,5}$")))
            {
                return true;
            }
            // Define Regex for car reg with 2 digits-two letters-up to 5 digits
            else if (Regex.IsMatch(regNo, "^[0-9]{2}[-][A-Za-z]{1,2}[-][0-9]{1,5}$"))
            {
                return true;
            }
            else
                return false;
        }
        // sent email
        public static void sentEmail(String fname, String sname, String make, String model, String email, String regNo, String date)
        {
            var fromAddress = new MailAddress("mail@gmail.com", "NCT");
            var toAddress = new MailAddress(email, fname + " " + sname);
            const string fromPassword = "***password***";
            const string subject = "NCT reminder.";
            string body = "Dear " + fname + " " + sname + "\n" +
                    "This is your NCT reminder. Please retain as you will not receive a renewal notice in the post." +
                    "\n\n\nThe NCT for your " + make + "  " + model + "\nRegistration Number  " + regNo + "\nDue on " + date;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        public static void sentAppConfirmEmail(string time, string date, string regNo, string uniqueAppID, string email, string centreName,string sname, string fname)
        {
            var fromAddress = new MailAddress("mail@gmail.com", "NCT");
            var toAddress = new MailAddress(email, fname + " " + sname);
            const string fromPassword = "***password***";
            const string subject = "NCT Appointment Confirmation.";
            string body = "Dear " + fname + " " + sname + "\n" +
                    "Please retain as you will not receive an Appointment Confirmation in the post." +
                    "\n\n\nAppointment Details for REG Number " + regNo + "\nDate: " + date + "\nTime: " + time + "\nLocation: " + centreName + "\nUnique Appointment ID: " + uniqueAppID;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
