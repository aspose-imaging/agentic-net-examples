// HOW-TO: Convert CMX Drawing to Transparent PNG with Alpha Channel in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample_transparent.png";

        // Global exception handling
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Configure rasterization options – set transparent background
                var rasterOptions = new CmxRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    // Preserve original page size
                    PageSize = cmxImage.Size
                };

                // Configure PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG with alpha channel
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
 * 1. When you need to display a CorelDRAW CMX illustration on a web page without a solid background, you can rasterize it to a PNG that preserves transparency.
 * 2. When integrating legacy CMX assets into a modern .NET application, converting them to PNG with an alpha channel allows seamless compositing with other UI elements.
 * 3. When preparing print‑ready graphics that require a transparent background for overlay, you can use this code to turn CMX drawings into lossless PNG files.
 * 4. When automating batch processing of CMX files for a digital asset pipeline, the snippet ensures each image is saved with a transparent background for downstream editing tools.
 * 5. When building a C# service that generates thumbnails from CMX drawings, saving them as transparent PNGs maintains visual fidelity and supports overlay effects.
 */
