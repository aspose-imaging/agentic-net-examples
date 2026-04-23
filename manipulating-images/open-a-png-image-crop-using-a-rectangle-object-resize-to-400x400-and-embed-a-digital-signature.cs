using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Crop using a rectangle (example: inset by 50 pixels on each side)
                var cropRect = new Rectangle(50, 50, image.Width - 100, image.Height - 100);
                image.Crop(cropRect);

                // Resize to 400x400 pixels
                image.Resize(400, 400);

                // Embed a digital signature with a valid password (>=4 characters)
                image.EmbedDigitalSignature("secure123");

                // Save the processed image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}