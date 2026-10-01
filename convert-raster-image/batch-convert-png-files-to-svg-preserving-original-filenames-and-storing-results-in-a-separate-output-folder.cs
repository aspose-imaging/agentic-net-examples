// HOW-TO: Batch Convert PNG Images to SVG Preserving Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in pngFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new SvgOptions();
                    image.Save(outputPath, options);
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
 * 1. When you need to generate scalable vector graphics from a collection of raster PNG logos for responsive web design.
 * 2. When an automated build process must convert product screenshots to SVG for inclusion in documentation without changing file names.
 * 3. When a desktop application has to export user‑uploaded PNG icons to SVG for high‑resolution printing.
 * 4. When a migration script moves legacy PNG assets to a vector‑based asset library while keeping the original folder structure.
 * 5. When a CI pipeline validates that all PNG assets are available as SVG equivalents for cross‑platform UI rendering.
 */
