using System.Text;
using System.Text.Json;


var game = new Game();
var defaultState = new FAlivePlayerState(game.CurrentPlayer);
game.SetState(defaultState);

for (int i = 0; i < 15; i++)
{
    game.MovePlayer();
    Thread.Sleep(1000);
}

class FPlayer
{
    public int Speed { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Hp { get; set; }
}

class FPawn
{
    public int Speed { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}

interface IFPlayerState
{
    void Move();
}

class FAlivePlayerState : IFPlayerState
{
    private readonly FPlayer _player;

    public FAlivePlayerState(FPlayer player)
    {
        _player = player;
    }
    public void Move()
    {
        Console.WriteLine("Moving FPlayer");
        
        _player.Y++;
    }
}

class FDeadPlayerState : IFPlayerState
{
    private readonly FPawn _pawn;

    public FDeadPlayerState(FPawn pawn)
    {
        _pawn = pawn;
    }
    
    public void Move()
    {
        Console.WriteLine("Moving FPawn");
        
        _pawn.X++;
    }
}

class Game
{
    private IFPlayerState? _currentState;
    
    public FPlayer CurrentPlayer { get; }
    public FPawn CurrentPawn { get; }

    public Game()
    {
        CurrentPlayer = new FPlayer()
        {
            Hp = 5,
            Speed = 1,
            X = 0,
            Y = 0
        };

        CurrentPawn = new FPawn();
    }

    public void SetState(IFPlayerState state)
    {
        _currentState = state;
    }

    public void MovePlayer()
    {
        if (_currentState is null)
        {
            throw new InvalidOperationException("State is null!");
        }
        
        _currentState.Move();

        if (CurrentPlayer.Hp <= 0)
        {
            return;
        }
        
        var result = Random.Shared.Next(0, 2);

        if (result == 1)
        {
            CurrentPlayer.Hp -= 5;
        }
        
        Console.WriteLine(CurrentPlayer.Hp);
        
        if (CurrentPlayer.Hp <= 0)
        {
            _currentState = new FDeadPlayerState(CurrentPawn);

            _ = Task.Run(async () =>
            {
                await Task.Delay(5000);

                CurrentPlayer.X = CurrentPlayer.Y = 0;
                
                CurrentPlayer.Hp = 6;
                
                _currentState = new FAlivePlayerState(CurrentPlayer);
            });
        }
    }
}


public static class RandomExtensions
{
    public static int NextInclusive(this Random source, int minValue, int maxValue)
    {
        return source.Next(minValue, maxValue) - 1 % minValue;
    }
}