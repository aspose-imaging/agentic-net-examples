// HOW-TO: Convert SVG to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.svg";
        string outputPath = "Output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    options.Source = new FileCreateSource(outputPath, false);
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
 * 1. When a web application needs to accept user‑uploaded SVG logos and serve them as PNG thumbnails for browsers that do not support SVG.
 * 2. When an automated build pipeline must batch‑convert a collection of vector icons into raster PNGs for inclusion in mobile app assets.
 * 3. When an email generation service requires converting SVG charts into PNG images to embed in HTML emails that only render raster formats.
 * 4. When a reporting tool needs to transform SVG diagrams into high‑resolution PNG files for PDF export.
 * 5. When a desktop utility must programmatically convert SVG files to PNG with Aspose.Imaging to maintain consistent image quality across platforms.
 */
