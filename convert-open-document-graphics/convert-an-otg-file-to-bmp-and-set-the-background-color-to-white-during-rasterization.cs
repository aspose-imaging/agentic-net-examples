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
            string outputPath = @"C:\Images\output.bmp";

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
                // Configure rasterization options with white background
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Set up BMP save options and attach rasterization options
                BmpOptions saveOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as BMP
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}