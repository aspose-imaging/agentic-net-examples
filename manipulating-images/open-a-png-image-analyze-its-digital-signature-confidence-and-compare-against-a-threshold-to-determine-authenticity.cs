using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input parameters
        string inputPath = "input.png";
        string password = "secret";
        int threshold = 80; // percentage threshold for authenticity

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the PNG image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Perform digital signature check with the specified password and threshold
            bool isAuthentic = image.IsDigitalSigned(password, threshold);

            // Output the result
            Console.WriteLine(isAuthentic
                ? $"Image is authentic (digital signature meets {threshold}% threshold)."
                : $"Image is NOT authentic (digital signature below {threshold}% threshold).");
        }
    }
}