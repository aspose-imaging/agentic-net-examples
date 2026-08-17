// HOW-TO: Batch Embed Digital Signature into PNG Files with Shared Password in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            const string inputDirectory = @"C:\Images\Input";
            const string outputDirectory = @"C:\Images\Output";

            // Shared password for the digital signature
            const string password = "sharedPassword";

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(outputDirectory);

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the corresponding output path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG, embed the digital signature, and save
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    image.EmbedDigitalSignature(password);
                    image.Save(outputPath);
                }

                // Log successful processing
                Console.WriteLine($"Signed and saved: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to protect a large set of product photos by embedding a password‑protected digital signature into every PNG before publishing them online.
 * 2. When a compliance team requires that all scanned documents saved as PNG be signed automatically in a batch to ensure authenticity and traceability.
 * 3. When a desktop application must add a shared digital signature to user‑uploaded PNG avatars and log each successful operation for audit purposes.
 * 4. When a CI/CD pipeline should embed a corporate digital watermark into PNG assets during build time, using a common password and reporting the results.
 * 5. When a legal firm wants to quickly sign thousands of PNG evidence images with a single password and keep a console log of the files that were processed successfully.
 */
