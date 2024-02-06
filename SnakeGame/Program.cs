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
        bool leftWallCollide = snake.SnakeCollideCheck(1, 1, SnakeCommandEnums.Left);
        if (leftWallCollide == false)
        {
            bool fruitCollideCheck = fruit.FruitCollidesSnake(snake.SnakePositions, SnakeCommandEnums.Left);
            if (fruitCollideCheck == true)
                fruit.IsGenerated = false;

            bool hasMoved = snake.MoveLeft(fruitCollideCheck);
            if (hasMoved == true)
                lastUsedKey = ConsoleKey.A;
        }
    }

    else if (key == ConsoleKey.D)
    {
        bool rightWallCollide = snake.SnakeCollideCheck(canvas.Width, 1, SnakeCommandEnums.Right);
        if (rightWallCollide == false)
        {
            bool fruitCollideCheck = fruit.FruitCollidesSnake(snake.SnakePositions, SnakeCommandEnums.Right);
            if (fruitCollideCheck == true)
                fruit.IsGenerated = false;

            bool hasMoved = snake.MoveRight(fruitCollideCheck);
            if (hasMoved == true)
                lastUsedKey = ConsoleKey.D;
        }
    }

    else if (key == ConsoleKey.W)
    {
        bool UpWallCollide = snake.SnakeCollideCheck(1, 1, SnakeCommandEnums.Up);
        if (UpWallCollide == false)
        {
            bool fruitCollideCheck = fruit.FruitCollidesSnake(snake.SnakePositions, SnakeCommandEnums.Up);
            if (fruitCollideCheck == true)
                fruit.IsGenerated = false;

            bool hasMoved = snake.MoveUp(fruitCollideCheck);
            if (hasMoved == true)
                lastUsedKey = ConsoleKey.W;
        }
    }

    else if (key == ConsoleKey.S)
    {
        bool downWallCollide = snake.SnakeCollideCheck(1, canvas.Height, SnakeCommandEnums.Down);
        if (downWallCollide == false)
        {
            bool fruitCollideCheck = fruit.FruitCollidesSnake(snake.SnakePositions, SnakeCommandEnums.Down);
            if (fruitCollideCheck == true)
                fruit.IsGenerated = false;

            bool hasMoved = snake.MoveDown(fruitCollideCheck);
            if (hasMoved == true)
                lastUsedKey = ConsoleKey.S;
        }
    }
    key = lastUsedKey;
}