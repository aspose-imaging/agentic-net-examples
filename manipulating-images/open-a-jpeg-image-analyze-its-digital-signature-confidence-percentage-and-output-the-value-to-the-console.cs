using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "sample.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Analyze digital signature confidence percentage.
                // An empty password is used when the password is unknown.
                int confidence = image.AnalyzePercentageDigitalSignature(string.Empty);

                // Output the confidence value
                Console.WriteLine($"Digital signature confidence: {confidence}%");
            }
        }
        catch (Aspose.Imaging.CoreExceptions.DigitalSignatureException ex)
        {
            // Handle digital signature related errors
            Console.Error.WriteLine($"Digital signature error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}