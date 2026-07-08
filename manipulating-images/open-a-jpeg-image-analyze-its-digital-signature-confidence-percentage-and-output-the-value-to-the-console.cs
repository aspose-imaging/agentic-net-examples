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
            string inputPath = @"C:\Images\sample.jpg";

            // Verify input file exists
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
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Check if the image is digitally signed (using empty password)
                bool isSigned = raster.IsDigitalSigned(string.Empty);

                // Analyze the confidence percentage of the digital signature
                int confidence = raster.AnalyzePercentageDigitalSignature(string.Empty);

                // Output the result to the console
                Console.WriteLine($"Digital signature confidence: {confidence}% (Signed: {isSigned})");
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
 * 1. When a developer needs to verify the authenticity of a JPEG file received from a client by checking its digital signature confidence percentage before processing it further.
 * 2. When an image processing pipeline must filter out unsigned or low‑confidence JPEG images to ensure only trusted assets are stored in a content management system.
 * 3. When a security‑aware application logs the digital signature confidence of uploaded product photos to detect potential tampering or forgery.
 * 4. When a batch job scans a directory of JPEG images and reports the signature confidence for each file to assist auditors in compliance verification.
 * 5. When a C# console utility needs to display whether a JPEG image is digitally signed and the confidence level, enabling developers to make runtime decisions about image usage.
 */