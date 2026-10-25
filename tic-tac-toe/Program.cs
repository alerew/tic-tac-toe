using tic_tac_toe;

Console.Title = "Крестики-нолики";

var game = new Game();

game.Draw();

Step(Obj.Cross);

game.Draw();

Step(Obj.Zero);

game.Draw();

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