namespace Farkle
{
    internal class Dice
    {
        public int value { get; private set; }
        private Random random = new Random();

        public ConsoleColor color;
        public bool isSelected;

        public Dice()
        {
            color = ConsoleColor.White;
            isSelected = false;
        }
        public int ThrowDice()
        {
            value = random.Next(1, 7);
            return value;
        }

        //Ändert den Status und die Farbe des Würfels bei Auswahl
        public void SwitchSelect()
        {
            if (isSelected)
            {
                color = ConsoleColor.White;
                isSelected = false;
            }
            else
            {
                color = ConsoleColor.Yellow;
                isSelected = true;
            }
        }
    }
}
