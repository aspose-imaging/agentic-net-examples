using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image inside a using block for proper disposal
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options to match the source size
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set up PNG save options and attach the rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = otgOptions
                };

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