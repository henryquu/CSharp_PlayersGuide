public static class RandomExtension {
    public static double NextDouble(this Random rnd, double max) {
        return rnd.NextDouble() * max;
    }

    public static string NextString(this Random rnd, params string[] strings) {
        return strings[rnd.Next(strings.Length)];
    }

    public static bool CoinFlip(this Random rnd, double heads=0.5) {
        if (heads < 0 || heads > 1) 
            return false;

        if (rnd.NextDouble() < heads) 
            return true;
        return false;
    }
}