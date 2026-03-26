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
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure BMP save options for 24‑bit color depth
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                // Rasterize vector WMF using appropriate options
                VectorRasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            // Save as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}