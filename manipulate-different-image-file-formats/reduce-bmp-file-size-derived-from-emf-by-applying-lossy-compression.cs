// HOW-TO: How To Reduce BMP Size From EMF Using Lossy Compression In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\source.emf";
            string outputPath = @"C:\Images\result.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP save options with lossy settings
                var bmpOptions = new BmpOptions
                {
                    // Reduce color depth to 8 bits per pixel
                    BitsPerPixel = 8,
                    // Use RGB (uncompressed) or you could use RLE-8 for further reduction
                    Compression = Aspose.Imaging.FileFormats.Bmp.BitmapCompression.Rgb,
                    // Set rasterization options to render the vector EMF onto a bitmap
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Optionally create an 8‑bit palette that approximates the original colors
                if (image is RasterImage rasterImage)
                {
                    bmpOptions.Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256);
                }

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
 * 1. When you need to convert vector EMF drawings to smaller BMP files for legacy Windows applications that only accept bitmap images.
 * 2. When you want to lower the storage footprint of generated BMPs by rasterizing EMF with an 8‑bit palette before saving.
 * 3. When you must create BMP thumbnails from high‑resolution EMF graphics while keeping file size under a specific limit.
 * 4. When you are preparing EMF‑based reports for email attachment and need the BMP version to be compact enough to avoid size restrictions.
 * 5. When you are building a batch processing tool that rasterizes multiple EMF files to BMP with lossy compression to speed up loading in resource‑constrained environments.
 */
