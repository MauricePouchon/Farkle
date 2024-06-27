namespace Farkle
{
    internal class Cup
    {
        protected List<Dice> dice;
        protected List<Dice> inactiveDice;

        private DiceBlocks diceBlocks = new DiceBlocks();
        private Calculator calculator = new Calculator();

        string Space = "  "; //Space between the dice
        public int round = 1;
        public int totalScore = 0;
        public int roundScore = 0;
        public int selectedScore = 0;

        private string hint;

        public Cup()
        {
            dice = new List<Dice>();
            inactiveDice = new List<Dice>();

            Dice dice1 = new Dice();
            Dice dice2 = new Dice();
            Dice dice3 = new Dice();
            Dice dice4 = new Dice();
            Dice dice5 = new Dice();
            Dice dice6 = new Dice();

            dice.Add(dice1);
            dice.Add(dice2);
            dice.Add(dice3);
            dice.Add(dice4);
            dice.Add(dice5);
            dice.Add(dice6);
        }

        private void ChangeColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void DrawScreen()
        {
            int counter = 0;

            Console.Clear();
            Console.WriteLine("Round: " + round);
            Console.WriteLine("Total Score: " + totalScore);
            Console.WriteLine("Round Score: " + roundScore);
            Console.WriteLine("Selected: " + selectedScore + "\n");
            DrawDice();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach (Dice d in dice)
            {
                counter++;
                Console.Write("    " + counter + "    " + Space);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nSelect a dice from 1 to " + counter);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press 'Space' to reroll / Press 'Enter' to confirm");
            Console.WriteLine(hint);
            SelectDice();
        }

        public void ThrowDice()
        {
            foreach (Dice d in dice)
            {
                d.ThrowDice();
            }
        }
        public void DrawDice()
        {
            foreach (Dice d in dice)
            {
                ChangeColor(d.color);

                Console.Write(diceBlocks.SelectBlock(1) + Space);
            }
            Console.WriteLine("");
            foreach (Dice d in dice)
            {
                ChangeColor(d.color);

                switch (d.value)
                {
                    case 1:
                        Console.Write(diceBlocks.SelectBlock(2) + Space);
                        break;
                    case 2:
                    case 3:
                        Console.Write(diceBlocks.SelectBlock(3) + Space);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        Console.Write(diceBlocks.SelectBlock(6) + Space);
                        break;
                }
            }
            Console.WriteLine("");
            foreach (Dice d in dice)
            {
                ChangeColor(d.color);

                switch (d.value)
                {
                    case 1:
                    case 3:
                    case 5:
                        Console.Write(diceBlocks.SelectBlock(4) + Space);
                        break;
                    case 2:
                    case 4:
                        Console.Write(diceBlocks.SelectBlock(2) + Space);
                        break;
                    case 6:
                        Console.Write(diceBlocks.SelectBlock(6) + Space);
                        break;
                }
            }
            Console.WriteLine("");
            foreach (Dice d in dice)
            {
                ChangeColor(d.color);

                switch (d.value)
                {
                    case 1:
                        Console.Write(diceBlocks.SelectBlock(2) + Space);
                        break;
                    case 2:
                    case 3:
                        Console.Write(diceBlocks.SelectBlock(5) + Space);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        Console.Write(diceBlocks.SelectBlock(6) + Space);
                        break;
                }
            }
            Console.WriteLine("");
            foreach (Dice d in dice)
            {
                ChangeColor(d.color);

                Console.Write(diceBlocks.SelectBlock(7) + Space);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SelectDice()
        {
            ConsoleKey pressedButton = ConsoleKey.Delete;

            while (pressedButton != ConsoleKey.End)
            {
                pressedButton = Console.ReadKey().Key;
                switch (pressedButton)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        dice[0].SwitchSelect();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (dice.Count >= 2)
                        {
                            dice[1].SwitchSelect();
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        if (dice.Count >= 3)
                        {
                            dice[2].SwitchSelect();
                        }
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        if (dice.Count >= 4)
                        {
                            dice[3].SwitchSelect();
                        }
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        if (dice.Count >= 5)
                        {
                            dice[4].SwitchSelect();
                        }
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        if (dice.Count >= 6)
                        {
                            dice[5].SwitchSelect();
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        RerollDice();
                        break;
                    case ConsoleKey.Enter:
                        EndTurn();
                        break;
                }
                selectedScore = calculator.Calculate(dice);
                DrawScreen();
            }
        }

        public void RerollDice()
        {
            roundScore += selectedScore;

            if (selectedScore != -10)
            {
                foreach (Dice d in dice)
                {
                    if (d.isSelected)
                    {
                        inactiveDice.Add(d);
                    }
                }
                foreach (Dice d in inactiveDice)
                {
                    if (dice.Contains(d))
                    {
                        dice.Remove(d);
                    }
                }

                if (dice.Count == 0)
                {
                    ResetDice();
                }

                ThrowDice();
            }
            else
            {
                hint = "You need to select at least one dice to be able to reroll!";
            }
        }

        public void ResetDice()
        {
            dice.Clear();

            Dice dice1 = new Dice();
            Dice dice2 = new Dice();
            Dice dice3 = new Dice();
            Dice dice4 = new Dice();
            Dice dice5 = new Dice();
            Dice dice6 = new Dice();

            dice.Add(dice1);
            dice.Add(dice2);
            dice.Add(dice3);
            dice.Add(dice4);
            dice.Add(dice5);
            dice.Add(dice6);
        }

        public void EndTurn()
        {
            roundScore += selectedScore;
            totalScore += roundScore;
            selectedScore = 0;
            roundScore = 0;
            round++;
            ResetDice();
            RerollDice();
        }
    }
}