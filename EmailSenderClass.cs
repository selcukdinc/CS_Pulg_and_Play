using System;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Windows.Forms;

namespace Plug_and_Play
{
    internal class EmailSenderClass
    {
        private readonly string _email, _password;
        string _baslik = "Plug_and_Play Uygulaması";
        public EmailSenderClass()
        {
            _email = "@outlook.com";
            _password = "";
        }

        // şifre yenileme epostası gönder
        public void ResetPassword(string userEmail, string pinCode, string referance)
        {
            try
            {
                // SMTP sunucusu ve port bilgisi
                string smtpAddress = "smtp-mail.outlook.com";
                int portNumber = 587; // Genellikle 587 veya 465
                bool enableSSL = true;

                // Gönderici ve alıcı bilgileri
                string emailFrom = _email;
                string password = _password;
                string emailTo = userEmail;
                string subject = $"{_baslik} Parola yenile";
                string body = $@"
                                <html>
                                    <body>
                                        <div align=""center"">
                                        <h2>{_baslik}</h2>
                                        <p>Parolanızı sıfırlamak için pin kodu: <strong>{pinCode}</strong></p>
                                        <p>Referans: <strong>{referance}</strong></p>
                                        <p>XML ile günlük kur bilgilerini çeken, </p>
                                        <p>C#'ta döviz bürosunda kayıtlı ve onaylı kullanıcılar tarafından işlemler gerçekleşir</p>
                                        <p>Github profilim: <a href='https://github.com/selcukdinc'>https://github.com/selcukdinc</a></p>
                                        </div>
                                    </body>
                                </html>";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true; // Eğer HTML formatında göndermek isterseniz true yapın

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }

                Console.WriteLine("E-posta gönderimi başarılı");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderilirken hata alındı : " + ex.Message);
            }
        }


        public void NewUser(string userEmail, string pinCode, string referance)
        {
            try
            {
                // SMTP sunucusu ve port bilgisi
                string smtpAddress = "smtp-mail.outlook.com";
                int portNumber = 587; // Genellikle 587 veya 465
                bool enableSSL = true;

                // Gönderici ve alıcı bilgileri
                string emailFrom = _email;
                string password = _password;
                string emailTo = userEmail;
                string subject = $"{_baslik} Yeni kullanıcı";
                string body = $@"
                                <html>
                                    <body>
                                        <div align=""center"">
                                        <h2>{_baslik}</h2>
                                        <p>Kaydınızın tamamlanması için pininizi girin, </p>
                                        <p>Kimliğinizi doğrulamak için pin kodu: <strong>{pinCode}</strong></p>
                                        <p>Referans: <strong>{referance}</strong></p>
                                        <p>XML ile günlük kur bilgilerini çeken, </p>
                                        <p>C#'ta döviz bürosunda kayıtlı ve onaylı kullanıcılar tarafından işlemler gerçekleşir</p>
                                        <p>Github profilim: <a href='https://github.com/selcukdinc'>https://github.com/selcukdinc</a></p>
                                        </div>
                                    </body>
                                </html>";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true; // Eğer HTML formatında göndermek isterseniz true yapın

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }

                Console.WriteLine("E-posta gönderimi başarılı");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderilirken hata alındı : " + ex.Message);
            }
        }
    }
}
