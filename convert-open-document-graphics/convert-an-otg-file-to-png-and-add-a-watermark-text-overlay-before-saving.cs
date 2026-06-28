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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                using (var pngOptions = new PngOptions())
                {
                    pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = vectorImage.Width,
                        PageHeight = vectorImage.Height
                    };

                    vectorImage.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to display vector graphics from legacy OTG files as PNG thumbnails with a company logo watermark for brand protection.
 * 2. When an e‑learning platform converts instructor‑provided OTG diagrams to PNG images and overlays a “Confidential – For Internal Use Only” text before publishing to the portal.
 * 3. When a print‑ready workflow transforms OTG artwork into PNG previews and adds a “Draft” watermark so reviewers can distinguish unfinished files.
 * 4. When a document management system ingests OTG schematics, rasterizes them to PNG, and stamps a timestamp watermark to track when the file was processed.
 * 5. When a mobile app downloads OTG icons, converts them to PNG for faster rendering, and applies a semi‑transparent watermark to prevent unauthorized reuse.
 */