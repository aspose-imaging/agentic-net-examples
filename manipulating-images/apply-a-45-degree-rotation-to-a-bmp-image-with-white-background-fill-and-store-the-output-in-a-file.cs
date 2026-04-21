using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output_rotated.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the loaded image is a raster image (BmpImage derives from RasterImage)
                if (image is RasterImage rasterImage)
                {
                    // Rotate 45 degrees clockwise, resize canvas to fit the rotated image,
                    // and fill the empty background with white color
                    rasterImage.Rotate(45f, true, Color.White);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the rotated image to the output path
                    rasterImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}