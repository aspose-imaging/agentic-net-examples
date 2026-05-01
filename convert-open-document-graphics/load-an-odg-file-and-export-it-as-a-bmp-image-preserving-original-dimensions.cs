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
        string inputPath = @"C:\temp\input.odg";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Verify that the input ODG file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options to preserve the original dimensions
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White, // optional background
                    PageSize = image.Size           // keep original size
                };

                // Configure BMP save options and attach the rasterization options
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}