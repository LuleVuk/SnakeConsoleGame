namespace SnakeGame
{
    public class Canvas
    {
        public int StartHeight { get; set; }
        public int StartWidth { get; set; }
        public int Height { get; set; }
        public int Width { get; set; } 

        public int ScoreTextWidth { get; set; }
        public int ScoreWidth { get; set; }
        public int Score { get; set; }

        public Canvas() 
        { 
            StartHeight = 1;
            StartWidth = 1;
            Height = 20;
            Width = 40;
            ScoreTextWidth = Width + 5;
            ScoreWidth = ScoreTextWidth + 8;
            Score = 0;
        }

        public void DrawCanvas() 
        {
            Console.Clear();
            for (int i = StartHeight; i <= Height; i++) 
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = StartHeight; i <= Height; i++)
            {
                Console.SetCursorPosition(Width, i);
                Console.Write("|");
            }
            for (int i = StartWidth; i <= Width; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = StartWidth; i <= Width; i++)
            {
                Console.SetCursorPosition(i, Height);
                Console.Write("-");
            }

            Console.SetCursorPosition(ScoreTextWidth, 1);
            Console.Write("Score: ");
        }

        public void updateScore() 
        {
            Console.SetCursorPosition(ScoreWidth, 1);
            Console.Write(Score);
        }
    }
}
