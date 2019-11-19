using System;
using System.Net.Mail;
using System.Linq;
using LoginNavigation.Models;

using Xamarin.Forms;

namespace LoginNavigation
{
    public partial class ForgotPassword : ContentPage
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        async void SendEmail(object sender, EventArgs e)
        {
            //Ensures that the email provided exists for a user within the system
            //Untested
            var u = App.Database.GetUserAsync(emailEntry.Text);
            if (u.Result.Email == emailEntry.Text)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    //A random 6 digit code mailed to the user
                    Random r = new Random();
                    var x = r.Next(0, 1000000);
                    VerifyCode.code = x.ToString("000000");
                    VerifyCode.sentTo = emailEntry.Text;

                    mail.From = new MailAddress("impactapp4330@gmail.com");
                    mail.To.Add(emailEntry.Text);
                    mail.Subject = "Reset Your Password";
                    mail.Body = "To reset your password, use the code below in the ImPACt app:\n\n" + VerifyCode.code;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("impactapp4330@gmail.com", "4hZj3M%cT&huQJr4");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                    //Sends the user to a page where they can enter the code to reset their password
                    await Navigation.PushAsync(new VerificationCode());
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count() - 2]);
                }
                //Displays an error message if the email failed to send
                catch
                {
                    messageLabel.Text = "Could not send email";
                }
            }
            //If the email does not exist for any user, an error message is given
            else
            {
                messageLabel.Text = "No account with that email exists";
            }
        }
    }
}
