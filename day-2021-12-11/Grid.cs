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

    public bool CanFlash(int x, int y) => _energyLevels[x + y * Width] > 9;
    public void Reset(int x, int y) => _energyLevels[x + y * Width] = 0;

    public void IncreaseAllLevels()
    {
        for (var i = 0; i < _energyLevels.Count; i++)
            _energyLevels[i] += 1;
    }

    public bool IsAllFlashes()
    {
        return _energyLevels.All(level => level == 0);
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
            if(y < Height - 1)
                result += Environment.NewLine;
        }
        return result;
    }
}