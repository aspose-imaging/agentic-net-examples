// HOW-TO: Validate PNG Digital Signature Confidence Against Threshold in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input path (PNG image to analyze)
        string inputPath = @"C:\Images\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Parameters for digital signature analysis
        string password = "mySecretPassword";   // password used when the image was signed
        int threshold = 80;                     // percentage threshold for authenticity

        try
        {
            // Load the PNG image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Fast check: is the image considered digitally signed?
                bool isSigned = image.IsDigitalSigned(password, threshold);

                // Detailed confidence percentage
                int confidence = image.AnalyzePercentageDigitalSignature(password);

                // Determine authenticity based on both checks
                bool isAuthentic = isSigned && confidence >= threshold;

                Console.WriteLine($"Digital Signature Detected: {isSigned}");
                Console.WriteLine($"Signature Confidence: {confidence}%");
                Console.WriteLine($"Authenticity (confidence >= {threshold}%): {isAuthentic}");
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
 * 1. When an e‑commerce platform needs to ensure product photos uploaded as PNG files have not been altered, it can use this code to verify the digital signature and reject tampered images.
 * 2. When a medical imaging system stores diagnostic scans as PNGs and must comply with regulatory audit trails, the code can confirm the image’s authenticity by checking the signature confidence.
 * 3. When a digital asset management solution wants to automatically flag PNG graphics that were signed by a trusted source, it can run this check to accept only images whose confidence meets a predefined threshold.
 * 4. When a secure document workflow requires that embedded PNG diagrams retain their original integrity, developers can employ this snippet to validate the signature before processing the file further.
 * 5. When a forensic analyst needs to quickly assess whether a PNG screenshot has been forged, the code provides a straightforward way to measure signature confidence and determine authenticity.
 */
