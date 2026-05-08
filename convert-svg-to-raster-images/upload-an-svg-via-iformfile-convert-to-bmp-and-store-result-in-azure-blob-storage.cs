using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input SVG path
            string inputPath = Path.Combine("Input", "image.svg");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output BMP path
            string outputPath = Path.Combine("Output", "image.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Set rasterization options for vector to raster conversion
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // BMP save options with the rasterization settings
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as BMP
                image.Save(outputPath, bmpOptions);
            }

            // TODO: Upload the BMP file at 'outputPath' to Azure Blob storage using appropriate SDK or HTTP request.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}