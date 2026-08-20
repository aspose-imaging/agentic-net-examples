// HOW-TO: Subtract Green Magic Wand Selection From Blue Area And Save As BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/result.bmp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask for the blue selection at (100, 100)
                // Subtract the green selection at (200, 200) from it
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100))
                    .Subtract(new MagicWandSettings(200, 200))
                    .Apply();

                // Save the resulting image as BMP
                image.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to remove a green object from a blue background in a PNG and output the cleaned image as a BMP for legacy Windows applications.
 * 2. When creating automated graphics pipelines that require precise region subtraction using Aspose.Imaging's Magic Wand tool in C#.
 * 3. When generating bitmap assets for game development where a specific color region must be excluded from another selection.
 * 4. When processing scanned documents to eliminate overlapping colored stamps before converting them to BMP format.
 * 5. When building a batch image editor that programmatically subtracts one color‑based mask from another and saves the result for further analysis.
 */
