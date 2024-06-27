namespace Farkle
{
    internal class DiceBlocks
    {
        //Blöcke zur Darstellung der verschiedenen Teile eines Würfels
        private string Block1 = ".-------.";
        private string Block2 = "|       |";
        private string Block3 = "|     O |";
        private string Block4 = "|   O   |";
        private string Block5 = "| O     |";
        private string Block6 = "| O   O |";
        private string Block7 = "'-------'";

        public DiceBlocks() { }

        public string SelectBlock(int value) => value switch
        {
            1 => Block1,
            2 => Block2,
            3 => Block3,
            4 => Block4,
            5 => Block5,
            6 => Block6,
            7 => Block7,
            _ => ""
        };
    }
}
