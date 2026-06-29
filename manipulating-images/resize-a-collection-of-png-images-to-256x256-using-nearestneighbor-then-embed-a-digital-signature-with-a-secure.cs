using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_resized.png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Load the image as a RasterImage
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Resize to 256x256 using default NearestNeighbour resample
                    image.Resize(256, 256);

                    // Embed digital signature with a secure password
                    image.EmbedDigitalSignature("secure123");

                    // Ensure the output directory exists before saving
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as PNG
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to batch‑process user‑uploaded PNG avatars for a web portal, resizing them to a uniform 256 × 256 pixel size with NearestNeighbor interpolation and protecting each file with a password‑protected digital signature using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform must generate thumbnail previews of product PNG images for mobile catalogs while ensuring the thumbnails cannot be tampered with, the code can resize the images to 256 × 256 and embed a secure digital signature.
 * 3. When a medical imaging system stores PNG scans that must be standardized to 256 × 256 pixels for machine‑learning models and also requires cryptographic verification of each image’s integrity, developers can use this routine to resize and sign the files.
 * 4. When a game developer prepares sprite sheets composed of PNG assets that need consistent dimensions and wants to embed a password‑protected signature to prevent unauthorized modification, the example provides a quick C# solution.
 * 5. When a government agency archives PNG documents and must both compress them to a fixed 256 × 256 resolution for storage efficiency and embed a digital signature with a secure password for audit trails, this code handles the batch operation automatically.
 */