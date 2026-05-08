using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access adjustment methods
                RasterImage rasterImage = (RasterImage)image;

                // Adjust brightness (range -255 to 255)
                int brightness = 50; // custom brightness value
                rasterImage.AdjustBrightness(brightness);

                // Adjust contrast (range -100 to 100)
                float contrast = 30f; // custom contrast value
                rasterImage.AdjustContrast(contrast);

                // Save the modified image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}