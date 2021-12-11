namespace day_2021_12_11;

public class Grid
{
    public int Width { get; }
    public int Height { get; }

    private readonly List<int> _energyLevels;
    
    public Grid(Data data)
    {
        Width = data.Width;
        Height = data.Height;
        _energyLevels = new List<int>(data.Digits);
    }

    public int GetLevel(int x, int y) => _energyLevels[x + y * Width];
    public void SetLevel(int x, int y, int level) => _energyLevels[x + y * Width] = level;

    public void Step()
    {
        for (var i = 0; i < _energyLevels.Count; i++)
            _energyLevels[i] += 1;
    }
    
    public void Flash(int sx, int sy)
    {
        for (var y = sy - 1; y <= sy + 1; y++)
        {
            if(y < 0 || y > Height - 1)
                continue;
            for (var x = sx - 1; x <= sx + 1; x++)
            {
                if(x < 0 || x > Width - 1)
                    continue;

                _energyLevels[x + y * Width] += 1;
            }
        }
    }

    public override string ToString()
    {
        var result = "";
        var p = 0;
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                result += _energyLevels[p++];
            }
            result += Environment.NewLine;
        }
        return result;
    }
}