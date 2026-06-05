using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\Input\sample.jpg";
        string outputPath = @"C:\Images\Output\sample_signed.jpg";

        // Minimum pixel count requirement (e.g., 800x600)
        const int MinPixelCount = 800 * 600;

        // Password used for digital signature
        const string password = "MySecretPassword";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image (supports single and multi‑page images)
            using (Image img = Image.Load(inputPath))
            {
                // Cast to RasterImage to access pixel dimensions and signature methods
                if (img is RasterImage rasterImg)
                {
                    // Calculate total pixel count
                    long pixelCount = (long)rasterImg.Width * rasterImg.Height;

                    // Embed digital signature only if pixel count meets the minimum requirement
                    if (pixelCount >= MinPixelCount)
                    {
                        rasterImg.EmbedDigitalSignature(password);
                    }

                    // Save the (potentially signed) image to the output path
                    rasterImg.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image type for digital signature embedding.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}