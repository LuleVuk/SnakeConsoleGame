namespace SnakeGame
{
    public class Fruit
    {
        public int Width {  get; set; }
        public int Height { get; set; }
        public bool IsGenerated { get; set; }

        public Fruit() 
        { 
            IsGenerated = false;
            Width = 0;
            Height = 0;
        }

        public void GenerateFruit(List<(int x, int y)> snakePositions, Canvas canvas)
        {
            var randomNumberGenerator = new Random();
            bool fruitCollidesWithSnakeCheck = false;
            int randomWidth;
            int randomHeight;

            do
            {
                randomWidth = randomNumberGenerator.Next(canvas.StartWidth + 1, canvas.Width - 1);
                randomHeight = randomNumberGenerator.Next(canvas.StartHeight + 1, canvas.Height -1);
                if (snakePositions.Any(x => x == (randomWidth, randomHeight)))
                {
                    fruitCollidesWithSnakeCheck = true;
                }
                fruitCollidesWithSnakeCheck = false;
            } while (fruitCollidesWithSnakeCheck == true);

            Width = randomWidth;
            Height = randomHeight;
            IsGenerated = true;
        }

        public void DrawFruit() 
        {
            Console.SetCursorPosition(Width,Height);
            Console.Write('@');
        }

        public bool FruitCollidesSnake(List<(int x, int y)> snakePositions, SnakeCommandEnums command) 
        {
            if (command == SnakeCommandEnums.Left)
            {
                var snakeHead = snakePositions.Last();
                if (snakeHead.x - 1 == Width && snakeHead.y == Height)
                    return true;
                return false;
            }
            else if (command == SnakeCommandEnums.Right)
            {
                var snakeHead = snakePositions.Last();
                if (snakeHead.x + 1 == Width && snakeHead.y == Height)
                    return true;
                return false;
            }
            else if (command == SnakeCommandEnums.Up)
            {
                var snakeHead = snakePositions.Last();
                if (snakeHead.y - 1 == Height && snakeHead.x == Width)
                    return true;
                return false;
            }
            else if (command == SnakeCommandEnums.Down)
            {
                var snakeHead = snakePositions.Last();
                if (snakeHead.y + 1 == Height && snakeHead.x == Width)
                    return true;
                return false;
            }
            else
                return false;
        }
    }
}
