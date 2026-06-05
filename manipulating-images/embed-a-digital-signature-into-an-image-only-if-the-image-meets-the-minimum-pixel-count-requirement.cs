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
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_signed.jpg";

            // Password for the digital signature
            string password = "SecretPassword";

            // Minimum pixel count required to embed a signature
            const long MinPixelCount = 500_000; // example threshold

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Work only with raster images (most common formats)
                if (image is RasterImage rasterImage)
                {
                    long pixelCount = (long)rasterImage.Width * rasterImage.Height;

                    // Embed the digital signature only if the image meets the size requirement
                    if (pixelCount >= MinPixelCount)
                    {
                        rasterImage.EmbedDigitalSignature(password);
                    }
                    else
                    {
                        Console.WriteLine($"Image pixel count ({pixelCount}) is below the minimum required ({MinPixelCount}). Signature not applied.");
                    }

                    // Save the (potentially) signed image to the output path
                    rasterImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a raster image and cannot be processed.");
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors and report them
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}