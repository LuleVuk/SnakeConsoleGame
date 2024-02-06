namespace SnakeGame
{
    public class Snake
    {
        public int Length { get; set; }
        public List<(int x, int y)> SnakePositions { get; set; }

        public Snake()
        {
            Length = 5;
            SnakePositions = new List<(int x, int y)>()
            {
                (10,10), (10,11), (10,12), (10,13), (10,14)
            };
        }

        public void DrawSnake()
        {
            for (int i = 0; i < SnakePositions.Count(); i++)
            {
                int positionX = SnakePositions[i].x;
                int positionY = SnakePositions[i].y;
                Console.SetCursorPosition(positionX, positionY);
                Console.Write("*");
            }
        }

        public bool MoveLeft(bool fruitCollideCheck)
        {
            var snakeLeangth = SnakePositions.Count();
            var snakeHeadPosition = SnakePositions[snakeLeangth - 1];
            (int x, int y) newSnakeHeadPosition = (snakeHeadPosition.x - 1, snakeHeadPosition.y);
            //Checks if the new snake head position collides with the snakes body
            if (SnakePositions[SnakePositions.Count() - 2].x == newSnakeHeadPosition.x)
                return false;

            SnakePositions.Add(newSnakeHeadPosition);
            Console.SetCursorPosition(SnakePositions.Last().x, SnakePositions.Last().y);
            if (fruitCollideCheck == false)
            {
                SnakePositions.RemoveAt(0);
            }
            else
            {
                var aaaaaaa = 2;
            }
            Console.Write("*");
            return true;
        }

        public bool MoveRight(bool fruitCollideCheck)
        {
            var snakeLeangth = SnakePositions.Count();
            var snakeHeadPosition = SnakePositions[snakeLeangth - 1];
            (int x, int y) newSnakeHeadPosition = (snakeHeadPosition.x + 1, snakeHeadPosition.y);

            //Checks if the new snake head position collides with the snakes body
            if (SnakePositions[SnakePositions.Count() - 2].x == newSnakeHeadPosition.x)
                return false;

            SnakePositions.Add(newSnakeHeadPosition);
            Console.SetCursorPosition(SnakePositions.Last().x, SnakePositions.Last().y);
            if (fruitCollideCheck == false)
            {
                SnakePositions.RemoveAt(0);
            }
            else
            {
                var aaaaaaa = 2;
            }

            Console.Write("*");
            return true;
        }
        public bool MoveUp(bool fruitCollideCheck)
        {
            var snakeLeangth = SnakePositions.Count();
            var snakeHeadPosition = SnakePositions[snakeLeangth - 1];
            (int x, int y) newSnakeHeadPosition = (snakeHeadPosition.x, snakeHeadPosition.y - 1);

            //Checks if the new snake head position collides with the snakes body
            if (SnakePositions[SnakePositions.Count() - 2].y == newSnakeHeadPosition.y)
                return false;

            SnakePositions.Add(newSnakeHeadPosition);
            Console.SetCursorPosition(SnakePositions.Last().x, SnakePositions.Last().y);
            if (fruitCollideCheck == false) 
            {
                SnakePositions.RemoveAt(0);
            }
            else
            {
                var aaaaaaa = 2;
            }
            Console.Write("*");
            return true;
        }

        public bool MoveDown(bool fruitCollideCheck)
        {
            var snakeLeangth = SnakePositions.Count();
            var snakeHeadPosition = SnakePositions[snakeLeangth - 1];
            (int x, int y) newSnakeHeadPosition = (snakeHeadPosition.x, snakeHeadPosition.y + 1);

            //Checks if the new snake head position collides with the snakes body
            if (SnakePositions[SnakePositions.Count() - 2].y == newSnakeHeadPosition.y)
                return false;

            SnakePositions.Add(newSnakeHeadPosition);
            Console.SetCursorPosition(SnakePositions.Last().x, SnakePositions.Last().y);
            if (fruitCollideCheck == false)
            {
                SnakePositions.RemoveAt(0);
            }
            else 
            {
                var aaaaaaa = 2;
            }
            Console.Write("*");
            return true;
        }

        public bool SnakeCollideCheck(int x, int y, SnakeCommandEnums command)
        {
            if (command == SnakeCommandEnums.Left)
            {
                var snakeHead = SnakePositions.Last();
                if (snakeHead.x - 1 == x)
                    return true;
                return false;
            }
            else if (command == SnakeCommandEnums.Right)
            {
                var snakeHead = SnakePositions.Last();
                if (snakeHead.x + 1 == x)
                    return true;
                return false;
            }
            else if (command == SnakeCommandEnums.Up)
            {
                var snakeHead = SnakePositions.Last();
                if (snakeHead.y - 1 == y)
                    return true;
                return false;
            }
            else if (command == SnakeCommandEnums.Down)
            {
                var snakeHead = SnakePositions.Last();
                if (snakeHead.y + 1 == y)
                    return true;
                return false;
            }
            else
                return false;

        }

        public void SnakeIncreaseLength() 
        {
            Length++;
        }

        public bool SnakeEatsSnake((int x, int y) snakeHeadPosition, List<(int x, int y)> snakePositions) 
        {
            var snakePositionsWithoutHead = snakePositions.Take(snakePositions.Count()-1);
            foreach (var snakePosition in snakePositionsWithoutHead) 
            {
                if (snakeHeadPosition == snakePosition)
                {
                    return true;
                }
                else 
                {
                    continue;
                }
            }
            return false;
        }
    }
}
