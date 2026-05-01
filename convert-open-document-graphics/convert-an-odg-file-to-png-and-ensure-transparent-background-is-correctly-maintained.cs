using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.odg";
            string outputPath = "sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options to keep transparency
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    PageSize = image.Size
                };

                // Set PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG preserving transparent background
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}