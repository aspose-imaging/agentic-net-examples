using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";
        // Shared password for digital signature
        string password = "secure123";

        try
        {
            // Ensure input directory exists; create if missing and exit
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Enumerate PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);

                // Ensure output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG as a RasterImage
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Embed the digital signature using the shared password
                    image.EmbedDigitalSignature(password);

                    // Save the signed image to the output path
                    image.Save(outputPath);
                }

                // Log successful signing
                Console.WriteLine($"Signed and saved: {outputPath}");
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
 * 1. When a developer needs to automatically add a password‑protected digital signature to every PNG in a folder before publishing them to a website.
 * 2. When a batch process must secure a collection of product‑catalog images by embedding a shared password signature and store the signed copies in a separate output directory.
 * 3. When an organization wants to ensure compliance by digitally signing all scanned PNG documents in a repository and keep a log of successful operations.
 * 4. When a CI/CD pipeline requires a step that signs all PNG assets with a common password to prevent tampering during deployment.
 * 5. When a desktop utility must process user‑uploaded PNG files, embed a shared digital signature for authentication, and save the signed versions for later verification.
 */