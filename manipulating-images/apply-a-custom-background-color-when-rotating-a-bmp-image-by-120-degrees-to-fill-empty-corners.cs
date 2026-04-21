using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access the Rotate method with background color
                RasterImage rasterImage = (RasterImage)image;

                // Rotate 120 degrees, resize proportionally, fill empty corners with a custom color
                rasterImage.Rotate(120f, true, Color.LightBlue);

                // Save the rotated image as BMP
                rasterImage.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}