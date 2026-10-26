using tic_tac_toe;

Console.Title = "Крестики-нолики";

var game = new Game();

Obj player = Obj.Cross;

game.Draw();

while (true)
{
    Step(player);
    game.Draw();

    var w = game.CheckWin();
    if (w is not null){
        Console.WriteLine($"Победили {(w == Obj.Cross ? "крестики" : "нолики")}");
        Restart();
        continue;
    }
    if (game.CheckDraw())
    {
        Console.WriteLine($"Ничья");
        Restart();
        continue;
    }    
    player = player == Obj.Cross ? Obj.Zero : Obj.Cross;
}

void Step(Obj player)
{
    bool flag;
    do
    {
        flag = true;
        Console.WriteLine($"\nХод {(player == Obj.Zero ? "нолика" : "крестика")}");
        Console.Write("Строка: ");
        flag &= int.TryParse(Console.ReadLine(), out int x);
        Console.Write("Столбец: ");
        flag &= int.TryParse(Console.ReadLine(), out int y);
        flag &= game.Set(x, y, player);
    } while (!flag);
}
void Restart()
{
    game.Clear();
    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
    Console.ReadKey();
    game.Draw();
}