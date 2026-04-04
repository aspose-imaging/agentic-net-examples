using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input files and output directory
        string[] inputPaths = { "input1.png", "input2.png", "input3.png" };
        string outputDirectory = "SignedImages";
        string password = "MySecretPassword";

        // Ensure the output directory exists (unconditional per requirements)
        Directory.CreateDirectory(outputDirectory);

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access pixel dimensions and signing methods
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine($"Unsupported image format: {inputPath}");
                    continue;
                }

                // Check minimum size requirement (8×8 pixels)
                if (rasterImage.Width < 8 || rasterImage.Height < 8)
                {
                    Console.Error.WriteLine($"Image too small (minimum 8×8 required): {inputPath}");
                    continue;
                }

                try
                {
                    // Embed the digital signature using the provided password
                    rasterImage.EmbedDigitalSignature(password);
                }
                catch (DigitalSignatureException ex)
                {
                    Console.Error.WriteLine($"Failed to embed signature in {inputPath}: {ex.Message}");
                    continue;
                }
                catch (ImageException ex)
                {
                    Console.Error.WriteLine($"Image processing error for {inputPath}: {ex.Message}");
                    continue;
                }

                // Prepare output path and ensure its directory exists (already created above)
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Save the signed image
                rasterImage.Save(outputPath);
            }
        }
    }
}