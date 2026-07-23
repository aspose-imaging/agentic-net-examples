using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP image
            BmpOptions bmpOptions = new BmpOptions();
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Fill image with a solid color
                RasterImage raster = (RasterImage)image;
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        raster.SetPixel(x, y, Aspose.Imaging.Color.FromArgb(255, 100, 150, 200));
                    }
                }

                // Embed digital signature with a valid password
                raster.EmbedDigitalSignature("secure123");

                // Save the image
                image.Save(outputPath, bmpOptions);
            }

            // Load the saved image for the invalid password test
            using (Image loadedImage = Image.Load(outputPath))
            {
                RasterImage raster = (RasterImage)loadedImage;
                try
                {
                    // Attempt to embed signature with a short (invalid) password
                    raster.EmbedDigitalSignature("123");
                }
                catch (Aspose.Imaging.CoreExceptions.ImageException ex)
                {
                    // Handle the expected exception
                    Console.WriteLine($"HANDLED: {ex.Message}");
                }
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
 * 1. When a developer must generate a BMP file with a solid background and embed a secure digital signature to ensure image authenticity in a .NET application.
 * 2. When a C# program needs to protect a BMP image with a password‑protected digital signature and later verify that the signature cannot be created with an insufficient password length.
 * 3. When an image processing workflow requires creating a raster image, filling it with a specific ARGB color, and saving it as a BMP using Aspose.Imaging.ImageOptions.
 * 4. When a developer wants to demonstrate proper exception handling for Aspose.Imaging.CoreExceptions.ImageException when an invalid (too short) password is supplied to EmbedDigitalSignature.
 * 5. When building a document management system that stores BMP thumbnails with embedded signatures and must catch and log errors if the signature password does not meet security requirements.
 */