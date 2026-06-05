using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "input.jpg";
        // Hardcoded password for the digital signature
        string password = "mySecretPassword";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital signature methods
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
                    return;
                }

                // Quick check if the image is digitally signed
                bool isSigned = raster.IsDigitalSigned(password);
                Console.WriteLine($"Is digitally signed: {isSigned}");

                // If signed, analyze the confidence percentage
                if (isSigned)
                {
                    int confidence = raster.AnalyzePercentageDigitalSignature(password);
                    Console.WriteLine($"Digital signature confidence: {confidence}%");
                }
                else
                {
                    Console.WriteLine("No digital signature detected.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}