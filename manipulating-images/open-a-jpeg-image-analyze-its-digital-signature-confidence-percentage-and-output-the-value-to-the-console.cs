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
                // Ensure the loaded image supports raster operations
                if (image is RasterImage rasterImage)
                {
                    // Password for digital signature extraction (empty if unknown)
                    string password = "";

                    // Analyze the digital signature confidence percentage
                    int confidence = rasterImage.AnalyzePercentageDigitalSignature(password);

                    Console.WriteLine($"Digital signature confidence: {confidence}%");
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}