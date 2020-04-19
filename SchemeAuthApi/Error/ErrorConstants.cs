namespace SchemeAuthApi.Error
{
    public static class ErrorConstants
    {
        // error message
        public const string Conflict = "Conflict";
        public const string ServiceUnavailable = "Service Unavailable";

        // validation
        public const string UsernameAlreadyExists = "Username is taken";
        public const string UsernameIsRequired = "Username is required";
        public const string EmailAlreadyExists = "Email is already registered";
        public const string EmailIsRequired = "Email is required";
        public const string PasswordIsRequired = "Password is required";
        public const string PasswordLengthInvalid = "Password must be at least 8 characters";
        public const string UsernamePasswordInvalid = "Incorrect Username and Password combination";
        public const string FullNameIsRequired = "Full name is required";
        public const string UsernameTooLong = "Username is limited to 20 characters";
        public const string EmailTooLong = "Email is limited to 100 characters";
        public const string FullNameTooLong = "Full Name is limited to 100 characters";
    }
}
