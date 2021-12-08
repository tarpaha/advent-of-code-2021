namespace day_2021_12_08
{
    public readonly struct Entry
    {
        public string[] Digits { get; }
        public string[] Output { get; }

        public Entry(string[] digits, string[] output)
        {
            Digits = digits;
            Output = output;
        }
    }
}