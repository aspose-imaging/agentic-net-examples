using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.bmp";

        // Path‑safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options to match the source size
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare BMP save options with lossy 8‑bpp palette reduction
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Generate a palette that approximates the source colors
                    Palette = ColorPaletteHelper.GetCloseImagePalette((RasterImage)image, 256),
                    // Use a simple compression (RGB) – optional, can be omitted
                    Compression = BitmapCompression.Rgb,
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized BMP with the specified options
                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to convert high‑resolution EMF vector graphics to a compact 8‑bpp BMP for legacy Windows applications, this code rasterizes the EMF and applies lossy palette reduction to shrink the file size.
 * 2. When an automated image‑processing pipeline must generate thumbnail BMPs from EMF reports while minimizing storage costs, the sample shows how to load, rasterize, and save with compression in C#.
 * 3. When a desktop software installer bundles documentation images and must meet a strict installer size limit, the code demonstrates converting EMF diagrams to compressed BMPs using Aspose.Imaging.
 * 4. When a web service creates printable BMP files from user‑uploaded EMF logos and wants to reduce bandwidth for download, this example provides the steps to apply 8‑bpp lossy compression in .NET.
 * 5. When a migration tool replaces vector EMF assets with raster BMPs for compatibility with older hardware, the snippet shows how to preserve visual fidelity while drastically lowering the BMP file size.
 */