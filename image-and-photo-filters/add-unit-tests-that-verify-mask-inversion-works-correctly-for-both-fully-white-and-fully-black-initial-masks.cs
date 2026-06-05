using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Temporary paths (not used for loading, only for directory creation compliance)
            string tempDir = Path.Combine(Path.GetTempPath(), "MaskInversionTests");
            string dummyOutputPath = Path.Combine(tempDir, "dummy.png");
            Directory.CreateDirectory(Path.GetDirectoryName(dummyOutputPath));

            // Test 1: Invert a fully white mask (expect fully transparent)
            bool whiteTestResult = TestInvertWhiteMask();
            Console.WriteLine($"Invert fully white mask test passed: {whiteTestResult}");

            // Test 2: Invert a fully black mask (expect fully opaque)
            bool blackTestResult = TestInvertBlackMask();
            Console.WriteLine($"Invert fully black mask test passed: {blackTestResult}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static bool TestInvertWhiteMask()
    {
        const int width = 10;
        const int height = 10;

        // Create a fully white grayscale mask
        var whiteMask = new ImageGrayscaleMask(width, height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                whiteMask[x, y] = 255; // opaque
            }
        }

        // Invert the mask
        var invertedMask = whiteMask.Invert();

        // Verify that all pixels are now transparent (opacity 0)
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (invertedMask.GetByteOpacity(x, y) != 0)
                    return false;
            }
        }
        return true;
    }

    static bool TestInvertBlackMask()
    {
        const int width = 10;
        const int height = 10;

        // Create a fully black (transparent) grayscale mask
        var blackMask = new ImageGrayscaleMask(width, height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                blackMask[x, y] = 0; // transparent
            }
        }

        // Invert the mask
        var invertedMask = blackMask.Invert();

        // Verify that all pixels are now opaque (opacity 255)
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (invertedMask.GetByteOpacity(x, y) != 255)
                    return false;
            }
        }
        return true;
    }
}