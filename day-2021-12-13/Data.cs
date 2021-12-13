namespace day_2021_12_13;

public class Data
{
    public enum Fold { Horz, Vert }

    public IEnumerable<(int, int)> Dots { get; }
    public IEnumerable<(Fold, int)> Folds { get; }

    public Data(IEnumerable<(int, int)> dots, IEnumerable<(Fold, int)> folds)
    {
        Dots = dots;
        Folds = folds;
    }
}