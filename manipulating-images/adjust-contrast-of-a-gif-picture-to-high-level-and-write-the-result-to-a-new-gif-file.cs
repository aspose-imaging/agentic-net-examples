// HOW-TO: Increase Contrast of GIF Image and Save as New GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage raster)
                {
                    raster.AdjustContrast(100);
                    raster.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image format.");
                }
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
 * 1. When you need to enhance the visual clarity of an animated GIF for a web banner by boosting its contrast before publishing.
 * 2. When processing user‑uploaded GIFs in a C# web service and you want to standardize contrast levels for consistent appearance across browsers.
 * 3. When creating a batch script that prepares GIF assets for a mobile app, increasing contrast to improve readability on small screens.
 * 4. When generating marketing emails that embed GIFs, adjusting contrast ensures the animation stands out in various email clients.
 * 5. When converting low‑contrast GIF screenshots into higher‑contrast versions for documentation or training materials in a .NET application.
 */
