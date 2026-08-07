using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (var inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_resized.png");

                // Ensure the output directory exists (unconditional as per rules)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image, resize, embed signature, and save
                using (PngImage image = (PngImage)Image.Load(inputPath))
                {
                    // Resize to 256x256 using default NearestNeighbourResample
                    image.Resize(256, 256);

                    // Embed digital signature with a secure password (>=4 characters)
                    image.EmbedDigitalSignature("secure123");

                    // Save the processed image
                    image.Save(outputPath);
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
 * 1. When a developer needs to batch‑process product thumbnail PNGs for an e‑commerce site, resizing each image to a uniform 256 × 256 pixels with NearestNeighbor interpolation and embedding a password‑protected digital signature to prevent unauthorized reuse.
 * 2. When building a mobile app that displays user‑generated avatars, the code can quickly shrink uploaded PNG files to 256 × 256 while adding a secure signature to verify the image’s integrity during sync.
 * 3. When preparing PNG assets for a machine‑learning dataset, a data engineer can use the snippet to standardize image dimensions and embed a password‑protected signature that later scripts can validate before training.
 * 4. When creating a secure digital catalog of artwork, a developer can resize each high‑resolution PNG to a web‑friendly 256 × 256 size and embed a digital signature with a strong password to ensure provenance.
 * 5. When automating the generation of QR‑code overlays for marketing materials, the routine can resize the PNG overlays to 256 × 256 and embed a password‑protected signature so the printed version can be authenticated programmatically.
 */