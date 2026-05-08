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
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample.bmp";

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
            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP save options with transparency support
                var bmpOptions = new BmpOptions
                {
                    // Bitfields compression preserves alpha channel
                    Compression = BitmapCompression.Bitfields,
                    // Set rasterization options for vector ODG source
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        // Transparent background to keep original transparency
                        BackgroundColor = Color.Transparent,
                        // Use the source image size for rasterization
                        PageSize = image.Size
                    }
                };

                // Save as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}