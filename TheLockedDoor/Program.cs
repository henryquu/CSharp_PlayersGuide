Door aa = new Door(2543);
Console.WriteLine(aa.State);
aa.Close();
aa.Open();
aa.Close();
aa.Lock();
aa.ChangePasscode();
aa.Unlock();


class Door {
    public LockState State { get; private set; }
    private int Passcode;

    public Door(int passcode) {
        Passcode = passcode;
        State = LockState.Open;
    }

    public bool Close() {
        if (State == LockState.Open){
            State = LockState.Closed;
            Console.WriteLine("Closed the door!");
            return true;
        }
        Console.WriteLine("Door is not open!");
        return false;
    }

    public bool Unlock() {
        if (State == LockState.Locked) {
            Console.Write("Enter the passcode: ");
            int passcode = Convert.ToInt32(Console.ReadLine());
            
            if (Passcode == passcode) {
                State = LockState.Closed;
                Console.WriteLine("Valid passcode, door ist now closed!");
                return true;
            }
            else {
                Console.WriteLine("The passcode is invalid!");
                return false;
            }
        }
        Console.WriteLine("Door is not locked!");
        return false;
    }

    public bool Open() {
        if (State == LockState.Open) {
            State = LockState.Closed;
            Console.WriteLine("Opened the door!");
            return true;
        }
        Console.WriteLine("Door needs to be unlocked!");
        return false;
    }

    public bool Lock() {
        if (State == LockState.Closed) {
            State = LockState.Locked;
            Console.WriteLine("Locked the door!");
            return true;
        }
        Console.WriteLine("Door needs to be unlocked!");
        return false;
    }

    public bool ChangePasscode() {
        Console.Write("Enter the current passcode: ");
        int passcode = Convert.ToInt32(Console.ReadLine());

        if (Passcode == passcode) {
            Console.Write("Enter the new passcode: ");
            Passcode = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Passcode changed succesfully!");
            return true;
        }

        Console.WriteLine("Wrong passcode.");
        return false;
    }
}

enum LockState { Open, Closed, Locked };