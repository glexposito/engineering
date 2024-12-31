namespace Design;

public class TicTacToe
{
    private readonly int _boardSize;
    private readonly int[][] _scores;

    public TicTacToe(int n)
    {
        _boardSize = n;
        _scores = new int[2][];
        _scores[0] = new int[_boardSize * 2 + 2];
        _scores[1] = new int[_boardSize * 2 + 2];
    }

    public int Move(int row, int col, int player)
    {
        var scorePosition = player - 1;
        
        _scores[scorePosition][row]++;
        if (_scores[scorePosition][row] == _boardSize)
        {
            return player;
        }
        
        _scores[scorePosition][col + _boardSize]++;
        if (_scores[scorePosition][col + _boardSize] == _boardSize)
        {
            return player;
        }
        
        if (row == col)
        {
            _scores[scorePosition][^2]++;
            if (_scores[scorePosition][^2] == _boardSize)
            {
                return player;
            }
        }
        
        if (row + col == _boardSize - 1)
        {
            _scores[scorePosition][^1]++;
            if (_scores[scorePosition][^1] == _boardSize)
            {
                return player;
            }
        }

        return 0;
    }
}