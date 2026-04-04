using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input path and password
        string inputPath = "input.jpg";
        string password = "myPassword";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the JPEG image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Fast check whether the image is digitally signed
            bool isSigned = image.IsDigitalSigned(password);

            // Calculate the confidence percentage of the embedded digital signature
            int confidence = image.AnalyzePercentageDigitalSignature(password);

            Console.WriteLine($"Is Signed: {isSigned}");
            Console.WriteLine($"Signature confidence: {confidence}%");
        }
    }
}