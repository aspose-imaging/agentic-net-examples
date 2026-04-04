using System;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Test 1: Invert a fully opaque (white) mask
        var whiteMask = new ImageGrayscaleMask(5, 5);
        for (int y = 0; y < whiteMask.Height; y++)
            for (int x = 0; x < whiteMask.Width; x++)
                whiteMask[x, y] = 255;

        var invertedWhite = whiteMask.Invert() as ImageGrayscaleMask;
        if (invertedWhite != null)
        {
            for (int y = 0; y < invertedWhite.Height; y++)
                for (int x = 0; x < invertedWhite.Width; x++)
                    if (invertedWhite[x, y] != 0)
                    {
                        Console.Error.WriteLine($"Test failed: Inverted white mask pixel not transparent at ({x},{y}).");
                        return;
                    }
        }

        // Test 2: Invert a fully transparent (black) mask
        var blackMask = new ImageGrayscaleMask(5, 5);
        for (int y = 0; y < blackMask.Height; y++)
            for (int x = 0; x < blackMask.Width; x++)
                blackMask[x, y] = 0;

        var invertedBlack = blackMask.Invert() as ImageGrayscaleMask;
        if (invertedBlack != null)
        {
            for (int y = 0; y < invertedBlack.Height; y++)
                for (int x = 0; x < invertedBlack.Width; x++)
                    if (invertedBlack[x, y] != 255)
                    {
                        Console.Error.WriteLine($"Test failed: Inverted black mask pixel not opaque at ({x},{y}).");
                        return;
                    }
        }

        Console.WriteLine("All mask inversion tests passed.");
    }
}