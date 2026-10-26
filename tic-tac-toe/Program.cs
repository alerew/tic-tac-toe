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
        break;
    }
    if (game.CheckDraw())
    {
        Console.WriteLine($"Ничья");
        break;
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
        flag = flag && game.Set(x, y, player);
    } while (!flag);
}