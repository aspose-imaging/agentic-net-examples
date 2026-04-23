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

        // Path safety checks
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
                // Set up rasterization options for vector to raster conversion
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure BMP save options with lossy settings (8‑bpp palette)
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8, // Reduce color depth to 8 bits per pixel
                    Compression = BitmapCompression.Rgb, // Use simple RGB compression
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized BMP image
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}