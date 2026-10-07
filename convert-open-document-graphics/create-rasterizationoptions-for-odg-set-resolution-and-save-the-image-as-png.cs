// HOW-TO: Convert ODG to PNG with 300 DPI Rasterization in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.png";

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
                    options.ResolutionSettings = new ResolutionSetting(300, 300);
                    options.VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
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
 * 1. When you need to generate high‑resolution PNG thumbnails from OpenDocument graphics (ODG) files in a C# application.
 * 2. When exporting ODG diagrams to PNG for web display while preserving exact page dimensions and a white background.
 * 3. When batch‑processing ODG assets to PNG with a fixed 300 dpi resolution for print‑ready output.
 * 4. When integrating Aspose.Imaging into a document conversion service that must rasterize vector ODG pages to raster PNG images.
 * 5. When creating PNG previews of ODG files in a Windows desktop tool that requires setting custom rasterization options such as page size and background color.
 */
