// HOW-TO: Convert OTG to PNG with Anti‑Aliasing Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.png");

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
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        SmoothingMode = SmoothingMode.AntiAlias
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
 * 1. When you need to generate high‑quality PNG thumbnails from OTG vector drawings for a web gallery, ensuring smooth edges with anti‑aliasing.
 * 2. When exporting OTG schematics to PNG for inclusion in PDF reports, and you want the rasterized image to retain crisp lines without jagged artifacts.
 * 3. When building a C# desktop application that converts user‑uploaded OTG files to PNG for printing, requiring a white background and anti‑aliased rendering.
 * 4. When automating batch conversion of OTG assets to PNG for a game’s texture pipeline, and you need consistent smoothing across all images.
 * 5. When integrating Aspose.Imaging into a server‑side service that receives OTG files via API and returns PNG previews with anti‑aliased rendering for better visual quality.
 */
