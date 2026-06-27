using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cmx";
        string outputPath = "output.bmp";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CMX vector image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Apply scaling factor of 2.0 by resizing width and height
                int newWidth = cmxImage.Width * 2;
                int newHeight = cmxImage.Height * 2;
                cmxImage.Resize(newWidth, newHeight);

                // Prepare BMP save options with 24‑bit color depth
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24
                };

                // Save as BMP
                cmxImage.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to convert legacy CorelDRAW CMX vector drawings into 24‑bit BMP files for use in Windows desktop applications.
 * 2. When a developer must upscale low‑resolution CMX schematics by a factor of two before printing on larger format printers that accept BMP input.
 * 3. When a developer wants to preserve vector detail while creating lossless 24‑bit BMP archives of CMX technical illustrations after resizing.
 * 4. When a developer automates batch processing of CMX assets to generate double‑sized BMP thumbnails for a web‑based product catalog.
 * 5. When a developer integrates CMX‑to‑BMP conversion with 24‑bit color depth into a C# image‑processing pipeline that requires a consistent raster format for downstream analysis.
 */