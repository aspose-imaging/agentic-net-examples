using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\sample.cdr";
            string outputPath = "output\\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR vector image
            using (var image = (CdrImage)Image.Load(inputPath))
            {
                // Configure PNG options with transparent background
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
                };

                // Remove background using default settings
                image.RemoveBackground(new RemoveBackgroundSettings());

                // Save the result as PNG
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
 * 1. When a designer needs to extract logo graphics from a CorelDRAW (CDR) file that uses the same color for the logo and the page background, this code can remove the background and save the logo as a transparent PNG.
 * 2. When an e‑commerce platform wants to display product illustrations from CDR files on a white website without the original background interfering, the code strips the background and outputs a PNG with an alpha channel.
 * 3. When a marketing automation script processes batch CDR assets and must generate web‑ready images with transparent backgrounds for social media ads, this snippet automates background removal and rasterization.
 * 4. When a document conversion service needs to preserve vector quality while converting CDR artwork to PNG while eliminating a matching background color, the code uses Aspose.Imaging’s RemoveBackgroundSettings and VectorRasterizationOptions.
 * 5. When a mobile app imports user‑provided CDR icons and requires them as transparent PNG assets for UI overlays, this example demonstrates loading the CDR, removing the background, and saving the result with truecolor with alpha.
 */