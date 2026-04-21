using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = "input.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the loaded image is a raster image
                var rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a raster image.");
                    return;
                }

                // Password used for digital signature extraction (empty if unknown)
                string password = "";

                // Analyze the digital signature confidence percentage
                int confidence = rasterImage.AnalyzePercentageDigitalSignature(password);

                // Output the result
                Console.WriteLine($"Digital signature confidence: {confidence}%");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}