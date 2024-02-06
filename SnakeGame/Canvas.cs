namespace SnakeGame
{
    public class Canvas
    {
        public int StartHeight { get; set; }
        public int StartWidth { get; set; }
        public int Height { get; set; }
        public int Width { get; set; } 

        public Canvas() 
        { 
            StartHeight = 1;
            StartWidth = 1;
            Height = 20;
            Width = 40;
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
        }
    }
}
