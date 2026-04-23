using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a new BMP image (100x100 pixels, 24 bits per pixel)
            var bmpOptions = new BmpOptions { BitsPerPixel = 24 };
            using (Image image = Image.Create(bmpOptions, 100, 100))
            {
                // Cast to RasterImage to access digital signature methods
                RasterImage raster = (RasterImage)image;

                // Embed a digital signature with a strong password
                raster.EmbedDigitalSignature("StrongPassword123");

                // Save the signed image
                raster.Save(outputPath);
            }

            // Verify the file exists before loading
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            // Load the image to attempt a signature with a short password
            using (Image loadedImage = Image.Load(outputPath))
            {
                RasterImage raster = (RasterImage)loadedImage;
                try
                {
                    // Attempt to embed with a short password (expected to fail)
                    raster.EmbedDigitalSignature("12");
                }
                catch (DigitalSignatureException ex)
                {
                    // Expected exception for an invalid/short password
                    Console.WriteLine($"Caught DigitalSignatureException: {ex.Message}");
                }
                catch (ImageException ex)
                {
                    // Fallback for other image-related errors
                    Console.WriteLine($"Caught ImageException: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            // Global error handling
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}