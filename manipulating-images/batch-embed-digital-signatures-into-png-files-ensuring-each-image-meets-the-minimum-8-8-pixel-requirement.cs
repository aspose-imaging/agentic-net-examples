using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input1.png",
                @"C:\Images\Input2.png",
                @"C:\Images\Input3.png"
            };

            string[] outputPaths = new string[]
            {
                @"C:\Images\Signed\Output1.png",
                @"C:\Images\Signed\Output2.png",
                @"C:\Images\Signed\Output3.png"
            };

            // Hardcoded password for digital signature
            const string password = "MySecretPassword";

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load PNG image
                using (PngImage pngImage = new PngImage(inputPath))
                {
                    // Verify minimum size requirement (8x8 pixels)
                    if (pngImage.Width < 8 || pngImage.Height < 8)
                    {
                        Console.Error.WriteLine($"Image too small (minimum 8x8): {inputPath}");
                        continue;
                    }

                    // Embed digital signature
                    pngImage.EmbedDigitalSignature(password);

                    // Save signed image
                    pngImage.Save(outputPath);
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
 * 1. When a developer needs to protect a collection of product catalog thumbnails by embedding a password‑protected digital signature into each PNG before publishing them online.
 * 2. When an e‑learning platform wants to verify the integrity of course slide images by batch signing PNG files that are at least 8×8 pixels and storing the signed copies in a secure folder.
 * 3. When a government agency automates the signing of scanned document stamps saved as PNGs to ensure authenticity while processing multiple files in a single run.
 * 4. When a mobile app backend prepares user‑generated avatars for distribution and embeds a digital signature into each PNG to prevent tampering during batch upload.
 * 5. When a digital asset management system enforces compliance by programmatically adding a password‑protected signature to every PNG asset that meets the minimum size requirement before archiving them.
 */