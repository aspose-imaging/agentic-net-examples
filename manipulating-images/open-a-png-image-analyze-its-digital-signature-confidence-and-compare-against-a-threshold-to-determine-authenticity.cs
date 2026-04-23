using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital signature methods
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Unsupported image type.");
                    return;
                }

                // Parameters for signature verification
                string password = "secret";          // password used when the image was signed
                int threshold = 80;                  // percentage threshold for authenticity

                // Fast check: is the image considered digitally signed?
                bool isSigned = rasterImage.IsDigitalSigned(password, threshold);
                Console.WriteLine($"Is digitally signed (threshold {threshold}%): {isSigned}");

                // Detailed analysis: actual similarity percentage
                int similarity = rasterImage.AnalyzePercentageDigitalSignature(password);
                Console.WriteLine($"Signature similarity: {similarity}%");

                // Save a copy of the image (optional)
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}