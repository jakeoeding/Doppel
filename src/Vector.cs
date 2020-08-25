using System;

public static class Vector
{
    public static int DotProduct(int[] vec1, int[] vec2)
    {
        if (vec1.Length != vec2.Length)
        {
            throw new InvalidOperationException("Input vectors must have the same number of components.");
        }

        int result = 0;

        for (int i = 0; i < vec1.Length; i++)
        {
            result += vec1[i] * vec2[i];
        }

        return result;
    }

    public static double Magnitude(int[] vec)
    {
        return Math.Sqrt(DotProduct(vec, vec));
    }

    public static double AngleBetween(int[] vec1, int[] vec2)
    {
        double vec1Mag = Magnitude(vec1);
        double vec2Mag = Magnitude(vec2);
        int dotProduct = DotProduct(vec1, vec2);
        return Math.Acos(dotProduct / (vec1Mag * vec2Mag));
    }
}
