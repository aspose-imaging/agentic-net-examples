using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample_transparent.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CmxImage to access vector‑specific properties
                CmxImage cmxImage = (CmxImage)image;

                // Set the background color to fully transparent
                cmxImage.BackgroundColor = Aspose.Imaging.Color.Transparent;
                cmxImage.HasBackgroundColor = true; // indicate that a background color is defined

                // Prepare PNG save options that support an alpha channel
                PngOptions pngOptions = new PngOptions
                {
                    // Truecolor with alpha preserves transparency
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Save the image as PNG with the specified options
                cmxImage.Save(outputPath, pngOptions);
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
 * 1. When converting legacy CorelDRAW CMX vector drawings to web‑ready PNG images that require a transparent background for overlay on HTML pages.
 * 2. When preparing CMX artwork for inclusion in a mobile app UI where the PNG must preserve alpha transparency to blend with dynamic backgrounds.
 * 3. When automating a batch process that extracts CMX files from a design repository and saves them as PNGs with transparent backgrounds for use in marketing collateral.
 * 4. When integrating Aspose.Imaging into a C# reporting tool that needs to render CMX diagrams as PNG thumbnails with no solid background color.
 * 5. When developing a document conversion service that receives CMX files and must output PNG files with truecolor and alpha channel to maintain visual fidelity in PDF generation.
 */