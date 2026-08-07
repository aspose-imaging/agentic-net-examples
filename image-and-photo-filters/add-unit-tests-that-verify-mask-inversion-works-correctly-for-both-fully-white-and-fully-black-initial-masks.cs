// HOW-TO: How To Invert A Grayscale Mask And Test It In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 10;
            int height = 10;

            // Test inversion of a fully white mask (all opaque)
            var whiteMask = new ImageGrayscaleMask(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    whiteMask[x, y] = 255; // opaque
                }
            }

            var invertedWhite = whiteMask.Invert();
            bool allTransparent = true;
            for (int y = 0; y < height && allTransparent; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!invertedWhite.IsTransparent(x, y))
                    {
                        allTransparent = false;
                        break;
                    }
                }
            }

            Console.WriteLine(allTransparent
                ? "White mask inversion passed"
                : "White mask inversion failed");

            // Test inversion of a fully black mask (all transparent)
            var blackMask = new ImageGrayscaleMask(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    blackMask[x, y] = 0; // transparent
                }
            }

            var invertedBlack = blackMask.Invert();
            bool allOpaque = true;
            for (int y = 0; y < height && allOpaque; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!invertedBlack.IsOpaque(x, y))
                    {
                        allOpaque = false;
                        break;
                    }
                }
            }

            Console.WriteLine(allOpaque
                ? "Black mask inversion passed"
                : "Black mask inversion failed");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify that a fully opaque (white) mask becomes completely transparent after inversion for accurate image compositing.
 * 2. When you want to confirm that a fully transparent (black) mask turns fully opaque after inversion as part of automated unit testing.
 * 3. When building a photo‑editing application that toggles region visibility by inverting grayscale masks at runtime.
 * 4. When creating a batch image‑processing pipeline that must ensure mask inversion works for both white and black masks before applying further filters.
 * 5. When debugging custom Magic Wand selection logic that relies on grayscale masks and requires reliable inversion behavior.
 */
