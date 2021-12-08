namespace day_2021_12_08
{
    public readonly struct Entry
    {
        public string[] Signals { get; }
        public string[] Output { get; }

        public Entry(string[] signals, string[] output)
        {
            Signals = signals;
            Output = output;
        }
    }
}