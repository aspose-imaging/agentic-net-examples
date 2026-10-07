// HOW-TO: Subtract Green Selection From Blue Area And Save As BMP In C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Blue selection point (example coordinates)
                int blueX = 100;
                int blueY = 100;

                // Green selection point (example coordinates)
                int greenX = 10;
                int greenY = 10;

                MagicWandTool.Select(image, new MagicWandSettings(blueX, blueY))
                    .Subtract(new MagicWandSettings(greenX, greenY))
                    .Apply();

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
 * 1. Use this code to remove an unwanted green object from a blue‑colored area of a PNG and save the cleaned image as a BMP for use in legacy Windows software.
 * 2. Apply the subtraction when generating a bitmap mask where the green selection represents a region to exclude from the blue selection, such as in GIS or medical image preprocessing.
 * 3. Use it to prepare game assets by cutting out green background elements from a blue sprite and exporting the result as a BMP for engines that require bitmap textures.
 * 4. Employ the technique to create custom icons where overlapping green and blue selections need to be combined by subtracting the green part, then saved in BMP format for compatibility with older systems.
 * 5. Implement this when automating batch processing of scanned documents to eliminate green stains from blue‑tinted sections and output the final pages as BMP files.
 */
