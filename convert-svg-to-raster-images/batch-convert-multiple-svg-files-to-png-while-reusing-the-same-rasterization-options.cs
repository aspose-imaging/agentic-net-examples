using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputPngs";

            // List of SVG files to convert (hardcoded)
            string[] svgFiles = new[]
            {
                "image1.svg",
                "image2.svg",
                "image3.svg"
            };

            // Reuse the same rasterization options for all conversions
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                // Example settings; adjust as needed
                BackgroundColor = Aspose.Imaging.Color.White,
                SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
            };

            PngOptions pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            foreach (string fileName in svgFiles)
            {
                string inputPath = Path.Combine(inputFolder, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(fileName) + ".png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Save as PNG using the shared options
                    image.Save(outputPath, pngSaveOptions);
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
 * 1. When a web application needs to generate thumbnail PNG previews for a batch of SVG icons stored on a server, this code can rasterize them with consistent background and smoothing settings.
 * 2. When an automated build pipeline must convert design assets from SVG to PNG for inclusion in a mobile app’s resource bundle, the shared rasterization options ensure uniform image quality across all files.
 * 3. When a reporting tool has to embed high‑resolution PNG charts that were originally created as SVG diagrams, the code can batch‑process the SVG files while preserving anti‑aliasing and text rendering hints.
 * 4. When a content management system imports user‑uploaded SVG logos and needs to store them as PNGs for faster browser rendering, this snippet provides a simple C# solution that reuses the same rasterization configuration.
 * 5. When a desktop utility converts a collection of SVG illustrations into PNG files for printing or offline viewing, the shared SvgRasterizationOptions guarantee consistent background color and smoothing for every conversion.
 */