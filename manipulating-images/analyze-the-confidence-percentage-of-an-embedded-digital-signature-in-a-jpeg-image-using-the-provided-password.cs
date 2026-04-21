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
                if (image is not RasterImage rasterImage)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
                    return;
                }

                // Password used for the digital signature
                string password = "yourPassword";

                // Fast check using default threshold (75%)
                bool isSigned = rasterImage.IsDigitalSigned(password);
                Console.WriteLine($"Is digitally signed (default threshold): {isSigned}");

                // Retrieve the confidence percentage of the embedded signature
                int confidence = rasterImage.AnalyzePercentageDigitalSignature(password);
                Console.WriteLine($"Digital signature confidence: {confidence}%");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}