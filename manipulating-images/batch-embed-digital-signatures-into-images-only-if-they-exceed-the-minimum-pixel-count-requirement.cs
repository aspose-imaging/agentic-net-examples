using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string[] inputPaths = new[]
        {
            @"C:\Images\Input1.jpg",
            @"C:\Images\Input2.jpg",
            @"C:\Images\Input3.jpg"
        };

        string outputDirectory = @"C:\Images\Signed";
        string password = "MySecretPassword";
        const int MinPixelCount = 500_000; // minimum number of pixels required

        try
        {
            // Ensure the output directory exists once
            Directory.CreateDirectory(outputDirectory);

            foreach (string inputPath in inputPaths)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output file path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Ensure the output directory for this file exists (redundant but follows rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (RasterImage image = Image.Load(inputPath) as RasterImage)
                {
                    if (image == null)
                    {
                        Console.Error.WriteLine($"Unsupported image format: {inputPath}");
                        continue;
                    }

                    // Check pixel count
                    long pixelCount = (long)image.Width * image.Height;
                    if (pixelCount >= MinPixelCount)
                    {
                        // Embed digital signature
                        image.EmbedDigitalSignature(password);
                    }

                    // Save the (possibly signed) image
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
 * 1. When a C# application must automatically add a password‑protected digital signature to high‑resolution JPEG photos (e.g., product catalog images) before publishing them to a web server.
 * 2. When a batch processing tool needs to embed a cryptographic signature into only those images that meet a minimum pixel count, ensuring low‑resolution thumbnails are left unchanged.
 * 3. When a document management system integrates Aspose.Imaging to verify image authenticity by signing large‑size PNG or BMP files during nightly import jobs.
 * 4. When a digital asset pipeline for a marketing campaign requires conditional signing of JPEG files larger than 500,000 pixels to comply with brand‑security policies.
 * 5. When a Windows service processes incoming image uploads, checks each image’s width × height, and embeds a secret password signature into qualifying images before storing them in a secure folder.
 */