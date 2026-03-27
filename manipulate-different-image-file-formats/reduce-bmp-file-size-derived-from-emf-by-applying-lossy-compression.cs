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
            // Set up rasterization options for EMF to bitmap conversion
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure BMP save options with lossy compression (8 bpp, RGB compression)
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 8,
                Compression = BitmapCompression.Rgb,
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized BMP image
            image.Save(outputPath, bmpOptions);
        }
    }
}