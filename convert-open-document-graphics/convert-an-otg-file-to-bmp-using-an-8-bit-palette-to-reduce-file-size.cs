// HOW-TO: Convert OTG Image to 8‑Bit BMP with Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.otg";
            string outputPath = @"C:\temp\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access pixel data
                RasterImage rasterImage = (RasterImage)image;

                // Prepare BMP save options with 8‑bit palette
                BmpOptions saveOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Generate a close 8‑bit palette for the image
                    Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256),
                    Compression = BitmapCompression.Rgb,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0)
                };

                // Save the image as BMP using the specified options
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to display legacy OTG graphics in a Windows application that only supports BMP files, you can use this code to convert them while keeping the file size small.
 * 2. When a batch‑processing pipeline must shrink large OTG assets for mobile or web delivery, the 8‑bit palette conversion reduces storage and bandwidth.
 * 3. When integrating a third‑party library that requires BMP input, this snippet lets you transform OTG files on the fly in a C# service.
 * 4. When archiving design assets and you want to preserve visual fidelity but limit disk usage, converting to an 8‑bit BMP with a close palette is ideal.
 * 5. When automating quality‑control scripts that validate image dimensions and resolution, the code provides a reliable way to load OTG, apply a palette, and save as BMP using Aspose.Imaging.
 */
