using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgImage = (SvgImage)image;

                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                svgImage.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to convert user‑uploaded SVG icons to high‑resolution PNG thumbnails with a consistent 300 DPI for display on retina screens.
 * 2. When a print‑ready workflow must rasterize vector logos from SVG files into PNG assets at a specific DPI to match the printer’s resolution settings.
 * 3. When an e‑learning platform generates course material images by aligning SVG diagram resolutions before saving them as PNGs to ensure uniform scaling across devices.
 * 4. When a desktop utility processes batch SVG drawings and outputs PNG files with a fixed DPI to maintain consistent image quality in PDF reports.
 * 5. When a mobile app prepares SVG illustrations for offline use by rasterizing them to PNG at a set resolution, guaranteeing the same visual fidelity on all devices.
 */