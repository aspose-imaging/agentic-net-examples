using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with anti‑aliasing
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Set up PNG save options and attach rasterization options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as PNG
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
 * 1. When a developer needs to generate high‑quality PNG previews of OpenDocument graphics (ODG) for a web gallery, enabling anti‑aliasing ensures the edges appear smooth on browsers.
 * 2. When exporting ODG diagrams from a CAD‑like application to PNG for inclusion in PDF reports, configuring SmoothingMode and TextRenderingHint reduces jagged lines and improves readability.
 * 3. When creating thumbnail images of ODG files for a document management system, anti‑aliased rasterization provides visually appealing thumbnails that match the original vector quality.
 * 4. When automating batch conversion of ODG assets to PNG for a mobile app, setting the background color and anti‑aliasing guarantees consistent, artifact‑free images across different screen densities.
 * 5. When integrating ODG charts into an e‑learning platform, using anti‑aliasing during conversion to PNG helps preserve the clarity of text and shapes for better learner experience.
 */