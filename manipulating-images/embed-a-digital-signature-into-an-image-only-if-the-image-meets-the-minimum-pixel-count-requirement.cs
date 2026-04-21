using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected exceptions
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/sample.jpg";
            string outputPath = "output/signed_sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital signature methods
                if (image is RasterImage rasterImage)
                {
                    // Minimum pixel count requirement (example: 800x600 = 480,000)
                    const long MinPixelCount = 800L * 600L;

                    // Calculate total pixel count
                    long pixelCount = (long)rasterImage.Width * rasterImage.Height;

                    // Embed digital signature only if the image meets the size requirement
                    if (pixelCount >= MinPixelCount)
                    {
                        string password = "MySecretPassword";
                        rasterImage.EmbedDigitalSignature(password);
                    }

                    // Save the (potentially signed) image to the output path
                    rasterImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a raster image and cannot be signed.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}