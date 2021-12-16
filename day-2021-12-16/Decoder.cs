namespace day_2021_12_16;

public static class Decoder
{
    public static int[] ConvertHexStringToBinary(string str)
    {
        var bits = new int[str.Length * 4];
        var p = 0;
        foreach (var number in str.Select(ch => ch <= '9' ? ch - '0' : ch - 'A' + 10))
        {
            bits[p++] = (number & 0b1000) != 0 ? 1 : 0; 
            bits[p++] = (number & 0b0100) != 0 ? 1 : 0; 
            bits[p++] = (number & 0b0010) != 0 ? 1 : 0; 
            bits[p++] = (number & 0b0001) != 0 ? 1 : 0;
        }
        return bits;
    }
}