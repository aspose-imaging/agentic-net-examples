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
            // Hardcoded input and output paths
            string inputPath = "input.psd";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image without resizing the canvas, fill empty areas with white
                image.NormalizeAngle(false, Color.White);

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the deskewed image as PNG
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
 * 1. When a developer needs to automatically correct the tilt of scanned Photoshop (PSD) files before publishing them as web‑ready PNG images, they can use this C# Aspose.Imaging code to deskew and convert the files.
 * 2. When an e‑commerce platform receives product mockups in PSD format that are slightly rotated, the code can straighten the images and save them as PNGs for faster page loads.
 * 3. When a digital archiving system must normalize the orientation of legacy PSD assets and store them in a lossless PNG format for long‑term preservation, this snippet provides the required deskew and export functionality.
 * 4. When a batch‑processing tool has to ensure that PSD artwork uploaded by designers is aligned correctly and then delivered as PNG thumbnails for preview galleries, the example demonstrates the necessary C# image processing steps.
 * 5. When a content management workflow requires converting tilted PSD source files into correctly oriented PNG files for email newsletters, the code shows how to programmatically normalize the angle and save the result.
 */