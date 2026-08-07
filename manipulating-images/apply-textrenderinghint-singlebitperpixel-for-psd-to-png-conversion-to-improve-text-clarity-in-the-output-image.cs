using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.psd";
        string outputPath = @"C:\Images\output.png";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with SingleBitPerPixel text rendering
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                    }
                };

                // Save as PNG
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
 * 1. When a developer needs to convert layered Photoshop PSD files containing crisp vector text into PNG thumbnails for a web gallery while preserving text sharpness.
 * 2. When an e‑commerce platform must generate product label images from PSD designs and ensure the printed text remains legible after conversion to PNG for display on mobile devices.
 * 3. When a digital asset management system automates batch conversion of PSD marketing assets to PNG previews and wants to avoid blurry text by using SingleBitPerPixel rendering.
 * 4. When a desktop publishing application exports PSD‑based flyers to PNG for email newsletters and requires the embedded text to stay clear at small sizes.
 * 5. When a CI/CD pipeline validates UI mockups by converting PSD mockups to PNG and needs accurate text rendering for visual regression testing.
 */