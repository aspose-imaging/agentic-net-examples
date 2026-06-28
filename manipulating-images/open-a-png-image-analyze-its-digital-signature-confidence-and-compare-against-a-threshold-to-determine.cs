using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\output\result.txt";

        // Ensure any runtime exception is caught and reported
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output directory (creates it if it does not exist)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital signature methods
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
                    return;
                }

                // Define password and threshold for authenticity check
                string password = "mySecretPassword";
                int threshold = 80; // percentage threshold (0-100)

                // Fast check: is the image digitally signed above the threshold?
                bool isSigned = rasterImage.IsDigitalSigned(password, threshold);

                // Detailed percentage analysis
                int similarity = rasterImage.AnalyzePercentageDigitalSignature(password);

                // Build result message
                string result = isSigned
                    ? $"Image is authentic. Signature similarity: {similarity}% (threshold: {threshold}%)."
                    : $"Image is NOT authentic. Signature similarity: {similarity}% (threshold: {threshold}%).";

                // Output to console
                Console.WriteLine(result);

                // Save result to a text file
                File.WriteAllText(outputPath, result);
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
 * 1. When a C# web application needs to verify that a PNG product photo uploaded by a vendor has not been altered, it can load the image with Aspose.Imaging and compare the digital signature confidence against a predefined threshold to confirm authenticity.
 * 2. When a medical imaging system stores diagnostic PNG scans, developers can use this code to ensure each scan’s digital signature meets the required confidence level before allowing clinicians to view the images.
 * 3. When a legal document management platform stores signed PNG signatures, the code can automatically check the signature similarity percentage to reject any document whose digital signature falls below the compliance threshold.
 * 4. When a secure corporate portal receives PNG screenshots as evidence, developers can run the digital signature analysis to validate that the images are genuine and have not been tampered with during transmission.
 * 5. When an online art marketplace wants to guarantee the originality of digital artwork saved as PNG files, the code can assess the digital signature confidence and flag any artwork that does not meet the authenticity threshold.
 */