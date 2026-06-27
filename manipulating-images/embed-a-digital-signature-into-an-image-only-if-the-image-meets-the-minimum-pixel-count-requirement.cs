using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_signed.jpg";

        // Password for the digital signature
        string password = "SecretPassword";

        // Minimum pixel count required to embed a signature
        const long MinPixelCount = 200_000; // example threshold

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Work only with raster images
                if (image is RasterImage rasterImage)
                {
                    long pixelCount = (long)rasterImage.Width * rasterImage.Height;

                    if (pixelCount >= MinPixelCount)
                    {
                        // Embed the digital signature using the provided password
                        rasterImage.EmbedDigitalSignature(password);
                        // Save the signed image
                        rasterImage.Save(outputPath);
                        Console.WriteLine("Digital signature embedded and image saved.");
                    }
                    else
                    {
                        Console.WriteLine($"Image pixel count ({pixelCount}) is below the minimum required ({MinPixelCount}). No signature applied.");
                        // Optionally save the original image to the output location
                        rasterImage.Save(outputPath);
                    }
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
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
 * 1. When a company needs to embed a tamper‑proof digital signature into high‑resolution product photos (e.g., JPEG or PNG) before uploading them to an e‑commerce platform, but only if the image meets a minimum pixel count to ensure the signature is not lost.
 * 2. When a medical imaging system must sign large DICOM‑converted raster images to guarantee authenticity, while skipping smaller thumbnail images that fall below the required pixel threshold.
 * 3. When a government agency archives scanned documents as TIFF files and wants to embed a password‑protected signature only on scans that are large enough to retain the signature’s integrity.
 * 4. When a digital asset management tool processes user‑uploaded JPEG images and automatically adds a secure signature to images larger than 200,000 pixels, saving the signed version to a designated folder.
 * 5. When a security‑focused mobile app generates high‑definition screenshots and needs to embed a password‑protected signature using Aspose.Imaging, but avoids signing low‑resolution screenshots that do not meet the pixel count requirement.
 */