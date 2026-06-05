using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png; // For PNG support

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\result.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                string password = "myPassword";   // Password used for the digital signature
                int threshold = 80;               // Desired confidence threshold (percentage)

                bool isSigned = false;
                int confidence = 0;

                // Determine the concrete image type and invoke the appropriate methods
                if (image is RasterImage rasterImage)
                {
                    isSigned = rasterImage.IsDigitalSigned(password, threshold);
                    confidence = rasterImage.AnalyzePercentageDigitalSignature(password);
                }
                else if (image is RasterCachedImage cachedImage)
                {
                    isSigned = cachedImage.IsDigitalSigned(password, threshold);
                    confidence = cachedImage.AnalyzePercentageDigitalSignature(password);
                }
                else if (image is RasterCachedMultipageImage cachedMulti)
                {
                    isSigned = cachedMulti.IsDigitalSigned(password, threshold);
                    confidence = cachedMulti.AnalyzePercentageDigitalSignature(password);
                }

                // Build the result message
                string result = isSigned
                    ? $"Image is authentic. Signature confidence: {confidence}% (>= {threshold}%)."
                    : $"Image is NOT authentic. Signature confidence: {confidence}% (< {threshold}%).";

                // Output to console
                Console.WriteLine(result);

                // Save the result to a text file
                File.WriteAllText(outputPath, result);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}