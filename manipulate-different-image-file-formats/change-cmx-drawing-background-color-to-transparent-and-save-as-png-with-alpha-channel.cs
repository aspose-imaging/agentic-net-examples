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
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\sample.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Set the background color to fully transparent
                cmxImage.BackgroundColor = Aspose.Imaging.Color.Transparent;
                // Indicate that the image does not have a background color
                cmxImage.HasBackgroundColor = false;

                // Prepare PNG save options with alpha channel support
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
 * 1. When converting legacy CorelDRAW CMX vector drawings to web‑ready PNG images that need a transparent background for overlay on HTML pages.
 * 2. When extracting graphics from a CMX file for use in a mobile app and the developer must preserve transparency by saving as PNG with an alpha channel.
 * 3. When automating a batch process that removes the default CMX background color and generates PNG assets for a UI design system.
 * 4. When integrating Aspose.Imaging in a C# service that receives CMX uploads and returns PNG thumbnails with no background for email newsletters.
 * 5. When preparing print‑ready artwork from CMX files but need a PNG version with transparent background for compositing in Photoshop or other raster editors.
 */