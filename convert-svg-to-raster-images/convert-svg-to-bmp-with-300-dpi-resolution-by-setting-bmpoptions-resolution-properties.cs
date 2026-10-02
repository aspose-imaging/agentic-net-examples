// HOW-TO: Convert SVG to BMP with 300 DPI Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/sample.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate high‑resolution bitmap thumbnails from vector SVG logos for print‑ready PDFs using C#.
 * 2. When a desktop application must export user‑drawn SVG diagrams as 300 DPI BMP files for legacy Windows imaging tools.
 * 3. When an automated batch process converts SVG assets to BMP with exact DPI settings to meet a printing vendor’s specifications.
 * 4. When you want to preserve the original SVG dimensions while rasterizing it to a BMP image for use in a .NET reporting engine.
 * 5. When a server‑side service creates BMP previews of SVG icons at 300 DPI to ensure consistent quality across different display devices.
 */
