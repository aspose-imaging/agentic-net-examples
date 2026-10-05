// HOW-TO: Convert Multiple ODG Files to PNG in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string[] inputPaths = new string[]
                {
                    "C:\\Images\\file1.odg",
                    "C:\\Images\\file2.odg",
                    "C:\\Images\\file3.odg"
                };
                string outputDirectory = "C:\\Converted";

                Parallel.ForEach(inputPaths, inputPath =>
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var options = new PngOptions();
                        image.Save(outputPath, options);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a large set of OpenDocument graphics (ODG) drawings to PNG thumbnails quickly for a web gallery.
 * 2. When an automated build pipeline must generate PNG previews of ODG assets in parallel to reduce overall processing time.
 * 3. When a desktop application imports user‑provided ODG diagrams and must render them as PNG images without blocking the UI thread.
 * 4. When a cloud service processes incoming ODG files concurrently to produce PNG files for downstream image‑analysis services.
 * 5. When a migration script moves legacy ODG artwork to a PNG‑based asset library and wants to leverage multi‑core CPUs for faster conversion.
 */
