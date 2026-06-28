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
        string inputPath = @"C:\Temp\sample.cmx";
        string outputPath = @"C:\Temp\sample.png";

        // Path safety checks as required
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Set background to fully transparent
                cmxImage.BackgroundColor = Aspose.Imaging.Color.Transparent;
                cmxImage.HasBackgroundColor = true; // indicate that a background color is defined

                // Prepare PNG save options with alpha channel support
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Save as PNG preserving transparency
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
 * 1. When a developer needs to convert legacy CorelDRAW CMX vector drawings into web‑ready PNG images with a transparent background for use on responsive websites.
 * 2. When an automated batch process must replace the solid background of CMX files with full alpha transparency before embedding the graphics in a mobile app UI.
 * 3. When a document‑generation system has to preserve the original CMX artwork while exporting it as a PNG with an alpha channel for inclusion in PDF reports.
 * 4. When a graphics pipeline requires programmatic control over the CMX background color to make it transparent and then save the result as a PNG for printing on transparent media.
 * 5. When a C# application integrates Aspose.Imaging to dynamically render CMX drawings with no background so they can be layered over other images in a photo‑editing tool.
 */