// HOW-TO: Convert ODG to PNG with White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate raster PNG previews of OpenDocument graphics for web thumbnails.
 * 2. When a reporting system must embed ODG diagrams into PDF reports that only accept PNG images.
 * 3. When an e‑learning platform converts teacher‑created ODG illustrations to PNG for consistent display across browsers.
 * 4. When a batch job processes a folder of ODG files and saves them as PNG with a white background to avoid transparency issues.
 * 5. When a desktop application requires converting vector ODG artwork to PNG at its original dimensions for printing workflows.
 */
