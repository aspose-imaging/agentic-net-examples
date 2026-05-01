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
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output\sample.png";

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
                // Create PNG save options
                PngOptions pngOptions = new PngOptions();

                // Configure OTG rasterization options
                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                {
                    // Set background color (e.g., white)
                    BackgroundColor = Color.White,
                    // Preserve original page size
                    PageSize = image.Size
                };

                // Assign rasterization options to the PNG save options
                pngOptions.VectorRasterizationOptions = otgRasterizationOptions;

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}