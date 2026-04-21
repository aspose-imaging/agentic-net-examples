using System;
using System.IO;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths (not used in the test but required by path‑safety rules)
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Run tests
            bool whiteMaskResult = TestMaskInversion(isInitiallyOpaque: true);
            bool blackMaskResult = TestMaskInversion(isInitiallyOpaque: false);

            Console.WriteLine($"White mask inversion test passed: {whiteMaskResult}");
            Console.WriteLine($"Black mask inversion test passed: {blackMaskResult}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Verifies that Invert() correctly flips a fully opaque (white) or fully transparent (black) mask.
    static bool TestMaskInversion(bool isInitiallyOpaque)
    {
        const int width = 10;
        const int height = 10;
        byte initialValue = isInitiallyOpaque ? (byte)255 : (byte)0;
        byte expectedInvertedValue = isInitiallyOpaque ? (byte)0 : (byte)255;

        // Create a grayscale mask and fill it uniformly.
        var mask = new ImageGrayscaleMask(width, height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                mask[x, y] = initialValue;
            }
        }

        // Invert the mask.
        var invertedMask = mask.Invert();

        // Verify every pixel has the expected inverted opacity.
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (invertedMask.GetByteOpacity(x, y) != expectedInvertedValue)
                {
                    return false;
                }
            }
        }

        return true;
    }
}