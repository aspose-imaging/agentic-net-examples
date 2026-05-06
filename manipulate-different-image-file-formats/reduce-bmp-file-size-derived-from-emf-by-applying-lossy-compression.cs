using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.bmp";

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
            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options to match the source size
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure BMP save options with lossy DXT1 compression
                var bmpOptions = new BmpOptions
                {
                    Compression = BitmapCompression.Dxt1, // lossy compression
                    BitsPerPixel = 8,                     // reduce color depth
                    VectorRasterizationOptions = vectorOptions
                };

                // Create an 8‑bit palette that approximates the source colors
                if (image is RasterImage rasterImage)
                {
                    bmpOptions.Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256);
                }

                // Save the rasterized BMP
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}