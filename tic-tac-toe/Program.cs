using tic_tac_toe;

Console.Title = "Крестики-нолики";

var game = new Game();

Obj player = Obj.Cross;

while (true)
{
    game.Draw();
    if (game.CheckWin())
        break;
    Step(player);
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