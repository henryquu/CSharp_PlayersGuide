string password;

while (true) {
    Console.Write("Enter the password: ");
    password = Console.ReadLine();

    Console.WriteLine(PasswordValidator.Validate(password));
}


class static PasswordValidator {
    static PasswordValidator() {

    }

    public bool Validate(string password) {
        bool upper = false, lower = false, number = false;

        if (password.Length < 6 || password.Length > 13)
            return false;

        foreach (char c in password) {
            if (c == 'T' || c == '&')
                return false;

            if (char.IsUpper(c)) 
                upper = true;
            if (char.IsLower(c))
                lower = true;
            if (char.IsNumber(c))
                number = true;
        }

        return (upper && lower && number);
    }
}