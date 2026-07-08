using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        // Minimum pixel count requirement (e.g., 800x600)
        const long MinPixelCount = 800 * 600;

        // Password used for digital signature
        const string Password = "mySecretPassword";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory);

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same file name in output directory)
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image img = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access Width/Height and signature methods
                    if (img is RasterImage rasterImg)
                    {
                        long pixelCount = (long)rasterImg.Width * rasterImg.Height;

                        // Embed signature only if pixel count meets the minimum requirement
                        if (pixelCount >= MinPixelCount)
                        {
                            rasterImg.EmbedDigitalSignature(Password);
                        }

                        // Save the (potentially modified) image
                        rasterImg.Save(outputPath);
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unsupported image type: {inputPath}");
                    }
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
 * 1. When a photographer wants to automatically add a password‑protected digital signature to all high‑resolution JPEG or PNG files in a folder before publishing them online.
 * 2. When a medical imaging system must embed a secure signature into DICOM images that are at least 800×600 pixels to ensure compliance with audit regulations.
 * 3. When an e‑commerce platform needs to batch‑process product photos, signing only those images that meet a minimum pixel count to prevent tampering of catalog images.
 * 4. When a government agency archives scanned documents and wants to embed a digital signature into TIFF files larger than a specified size to guarantee authenticity.
 * 5. When a content management workflow requires adding a password‑protected signature to large PNG assets while leaving smaller icons unchanged.
 */