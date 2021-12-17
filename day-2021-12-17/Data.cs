namespace day_2021_12_17;

public class Data
{
    public int XMin { get; }
    public int XMax { get; }
    public int YMin { get; }
    public int YMax { get; }

    public Data(int xMin, int xMax, int yMin, int yMax)
    {
        XMin = xMin;
        XMax = xMax;
        YMin = yMin;
        YMax = yMax;
    }
}