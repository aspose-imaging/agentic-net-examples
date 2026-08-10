// HOW-TO: Get Digital Signature Confidence Percentage of a JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input path and password
        string inputPath = "input.jpg";
        string password = "myPassword";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Get the confidence percentage of the embedded digital signature
                int confidence = image.AnalyzePercentageDigitalSignature(password);

                // Optionally, determine if the image is considered signed using the default threshold (75%)
                bool isSigned = image.IsDigitalSigned(password);

                Console.WriteLine($"Digital signature confidence: {confidence}%");
                Console.WriteLine($"Is image signed (default threshold): {isSigned}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify the authenticity of a JPEG received from a partner by checking its digital signature confidence.
 * 2. When you want to enforce a policy that only images with a signature confidence above a certain threshold are accepted in a document management system.
 * 3. When you are building an audit trail that records whether each uploaded image is digitally signed and how strong the signature is.
 * 4. When you need to programmatically reject tampered JPEG files by comparing the confidence value against the expected level.
 * 5. When you are integrating image security checks into a C# web API that validates user‑submitted photos before processing them.
 */
