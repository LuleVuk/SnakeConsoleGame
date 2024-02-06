using SnakeGame;

bool isFinished = false;
Canvas canvas = new Canvas();
Snake snake = new Snake();
Fruit fruit = new Fruit();
ConsoleKey key = ConsoleKey.D;
Console.SetBufferSize(400, 400);
ConsoleKey lastUsedKey = key;
while (isFinished == false)
{
    bool wallCollide = false;
    if (lastUsedKey == ConsoleKey.A || lastUsedKey == ConsoleKey.D)
        Thread.Sleep(100);
    else
        Thread.Sleep(200);
    if (fruit.IsGenerated == false)
    {
        fruit.GenerateFruit(snake.SnakePositions, canvas);
    }

    canvas.DrawCanvas();
    snake.DrawSnake();
    fruit.DrawFruit();
    if (Console.KeyAvailable == true)
    {
        key = Console.ReadKey(true).Key;
    }

    if (key == ConsoleKey.A)
    {
        wallCollide = snake.SnakeCollideCheck(1, 1, SnakeCommandEnums.Left);
        if (wallCollide == false)
        {
            bool fruitCollideCheck = fruit.FruitCollidesSnake(snake.SnakePositions, SnakeCommandEnums.Left);
            if (fruitCollideCheck == true)
            {
                fruit.IsGenerated = false;
                canvas.Score++;
            }

            bool hasMoved = snake.MoveLeft(fruitCollideCheck);
            if (hasMoved == true)
                lastUsedKey = ConsoleKey.A;
        }
    }

    else if (key == ConsoleKey.D)
    {
        wallCollide = snake.SnakeCollideCheck(canvas.Width, 1, SnakeCommandEnums.Right);
        if (wallCollide == false)
        {
            bool fruitCollideCheck = fruit.FruitCollidesSnake(snake.SnakePositions, SnakeCommandEnums.Right);
            if (fruitCollideCheck == true)
            {
                fruit.IsGenerated = false;
                canvas.Score++;
            }

            bool hasMoved = snake.MoveRight(fruitCollideCheck);
            if (hasMoved == true)
                lastUsedKey = ConsoleKey.D;
        }
    }

    else if (key == ConsoleKey.W)
    {
        wallCollide = snake.SnakeCollideCheck(1, 1, SnakeCommandEnums.Up);
        if (wallCollide == false)
        {
            bool fruitCollideCheck = fruit.FruitCollidesSnake(snake.SnakePositions, SnakeCommandEnums.Up);
            if (fruitCollideCheck == true)
            {
                fruit.IsGenerated = false;
                canvas.Score++;
            }

            bool hasMoved = snake.MoveUp(fruitCollideCheck);
            if (hasMoved == true)
                lastUsedKey = ConsoleKey.W;
        }
    }

    else if (key == ConsoleKey.S)
    {
        wallCollide = snake.SnakeCollideCheck(1, canvas.Height, SnakeCommandEnums.Down);
        if (wallCollide == false)
        {
            bool fruitCollideCheck = fruit.FruitCollidesSnake(snake.SnakePositions, SnakeCommandEnums.Down);
            if (fruitCollideCheck == true) 
            {
                fruit.IsGenerated = false;
                canvas.Score++;
            }

            bool hasMoved = snake.MoveDown(fruitCollideCheck);
            if (hasMoved == true)
                lastUsedKey = ConsoleKey.S;
        }
    }
    canvas.updateScore();
    var snakeEatSnakeCheck = snake.SnakeEatsSnake(snake.SnakePositions.Last(), snake.SnakePositions);
    if (snakeEatSnakeCheck || wallCollide) 
    { 
        isFinished = true;
    }
    key = lastUsedKey;
}

Console.Clear();
Console.WriteLine("GAME OVER");
Console.ReadLine();