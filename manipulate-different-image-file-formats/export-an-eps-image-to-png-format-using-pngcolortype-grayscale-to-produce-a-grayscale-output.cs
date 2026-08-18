// HOW-TO: Export EPS to Grayscale PNG in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions
                {
                    ColorType = PngColorType.Grayscale,
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, options);
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
 * 1. When a developer needs to convert vector EPS artwork into a lightweight grayscale PNG for inclusion in a PDF report.
 * 2. When an application must generate print‑ready grayscale thumbnails from EPS logos for a catalog website.
 * 3. When a batch process has to archive legacy EPS files as lossless grayscale PNGs to reduce storage while preserving detail.
 * 4. When a scientific imaging tool requires converting EPS plots to grayscale PNGs for consistent display on monochrome monitors.
 * 5. When a mobile app needs to render EPS diagrams as grayscale PNG images to improve rendering speed and reduce memory usage.
 */
