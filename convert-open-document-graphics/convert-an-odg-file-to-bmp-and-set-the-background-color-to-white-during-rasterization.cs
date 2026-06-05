using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample.bmp";

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

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with white background
                OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Set BMP save options and attach rasterization options
                BmpOptions saveOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image as BMP
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}