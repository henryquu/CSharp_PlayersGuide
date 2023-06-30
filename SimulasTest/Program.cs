ChestState state = ChestState.Locked;
string action = "";

while (true) {
    if (state == ChestState.Locked) {
        while (action != "unlock") {
            Console.Write("The chest is locked. What do you want to do? ");
            action = Console.ReadLine();
        }
        state = ChestState.Closed;
    }
    else if (state == ChestState.Closed) {
        while (action != "lock" && action != "open") {
            Console.Write("The chest is unlocked. What do you want to do? ");
            action = Console.ReadLine();
        }
        
        if (action == "lock")
            state = ChestState.Locked;
        else
            state = ChestState.Open;
    }
    else {
        while (action != "close") {
            Console.Write("The chest is open. What do you want to do? ");
            action = Console.ReadLine();
        }
        state = ChestState.Closed;
    }
}

enum ChestState { Open, Closed, Locked }