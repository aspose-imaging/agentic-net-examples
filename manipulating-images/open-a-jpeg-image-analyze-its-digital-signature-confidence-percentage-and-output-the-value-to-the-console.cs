// HOW-TO: Get Digital Signature Confidence Percentage From a JPEG in C# (Aspose.Imaging for .NET)
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

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Ensure we have a raster image to work with
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Analyze digital signature confidence (empty password used here)
                string password = "";
                int confidence = rasterImage.AnalyzePercentageDigitalSignature(password);

                // Output the confidence percentage
                Console.WriteLine($"Digital signature confidence: {confidence}%");
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
 * 1. When you need to verify that a JPEG file has not been tampered with by checking its embedded digital signature confidence before processing it further.
 * 2. When building an automated workflow that validates incoming images from a client portal and logs the signature confidence to ensure authenticity.
 * 3. When integrating security checks into a C# application that extracts and reports the digital signature confidence of scanned documents saved as JPEGs.
 * 4. When performing compliance audits that require you to programmatically read the digital signature confidence of product photos stored in JPEG format.
 * 5. When creating a diagnostic tool that reads a JPEG’s digital signature confidence and displays it in the console for troubleshooting image integrity issues.
 */
