namespace Game{
    public class Game {
        private int manticore;
        private int city;
        private int Round {
            get; set;
        }

        public Game(Pilot.IPilot Pilot, int manticore = 10, int city = 15) {
            this.manticore = manticore;
            this.city = city;

            Round = 1;

            int distance = Pilot.GetPosition();
            int guessed = 0;
            int damage;

            while (manticore > 0 && city > 0) {
                damage = CurrentDamage(Round);

                TextMessages.TextMessages.RoundStart(Round, city, manticore, damage);

                guessed = Player.Player.GetGuess("Enter desired cannon range: ");
                if (guessed == distance)
                    manticore -= damage;

                TextMessages.TextMessages.Distance(distance, guessed);

                if (manticore > 0) {
                    city--;
                    Round++;
                }
            }
            TextMessages.TextMessages.GameOver(city, manticore);
        }

        int CurrentDamage(int round) {
            int damage = (round % 5 == 0) ? 5 : 1;
            damage *= (round % 3 == 0) ? 3 : 1;

            return damage;
        }

    }
}