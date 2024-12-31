namespace Design;

public class SnakeGame
{
    private readonly int _width;
    private readonly int _height;
    private readonly LinkedList<Position> _body = [];
    private readonly Queue<Position> _food = [];

    public SnakeGame(int width, int height, int[][]? food)
    {
        _width = width;
        _height = height;
        Position head = new(0, 0);
        _body.AddFirst(head);

        if (food is null) return;
        foreach (var meal in food)
        {
            _food.Enqueue(new Position(meal[0], meal[1]));
        }
    }

    public int Move(string direction)
    {
        var head = _body.First!.Value;
        var newHead = direction switch
        {
            "U" => head with { Row = head.Row - 1 },
            "D" => head with { Row = head.Row + 1 },
            "L" => head with { Column = head.Column - 1 },
            _ => head with { Column = head.Column + 1 }
        };

        if (!IsValidMove(newHead))
        {
            return -1;
        }

        if (_food.Count > 0 && _food.Peek() == newHead)
        {
            _food.Dequeue();
        }
        else
        {
            _body.RemoveLast();
        }

        if (IsEatingItself(newHead)) return -1;

        _body.AddFirst(newHead);

        return _body.Count - 1;
    }

    private bool IsEatingItself(Position newHead)
    {
        return _body.Contains(newHead);
    }

    private bool IsValidMove(Position position)
    {
        return position.Row >= 0
               && position.Row < _height
               && position.Column >= 0
               && position.Column < _width;
    }

    private record Position(int Row, int Column);
}