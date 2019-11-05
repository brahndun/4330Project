using System;
namespace LoginNavigation
{
    public class VerificationCode
    {
        //Global variable that keeps track of a verification code if the user requests one
        public static string code;
        //The email that the code was sent to
        public static string sentTo;
    }
}
