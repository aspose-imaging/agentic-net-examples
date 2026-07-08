using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Define the rectangular area for selective background removal
                var selectionRect = new Rectangle(100, 100, 300, 200);
                cdrImage.Crop(selectionRect);

                // Remove background from the cropped area
                cdrImage.RemoveBackground();

                // Prepare PNG options with transparent background
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = cdrImage.Size
                    }
                };

                // Save the rasterized image
                cdrImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract a specific portion of a CorelDRAW (CDR) illustration, remove its background, and save it as a transparent PNG for web publishing.
 * 2. When an e‑commerce system must generate product thumbnails by cropping a defined rectangle from a CDR file, stripping the background, and exporting the result as a PNG with an alpha channel.
 * 3. When a marketing automation tool has to prepare logo assets by selecting a rectangular area in a CDR vector image, making the background transparent, and rasterizing it to a PNG for email campaigns.
 * 4. When a desktop publishing workflow requires isolating a diagram region inside a CDR file, removing its background, and exporting the cropped area as a high‑quality PNG for inclusion in PDF reports.
 * 5. When a mobile app needs to dynamically render a portion of a CDR vector graphic with a transparent background, using C# cropping and background removal before saving the rasterized image as PNG.
 */