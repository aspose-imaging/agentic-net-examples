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
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.bmp";

        try
        {
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
                // Set up rasterization options to match the source size
                var otgRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure BMP options with transparency support (Bitfields compression)
                var bmpOptions = new BmpOptions
                {
                    Compression = BitmapCompression.Bitfields,
                    VectorRasterizationOptions = otgRasterizationOptions
                };

                // Save as BMP preserving transparency
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}