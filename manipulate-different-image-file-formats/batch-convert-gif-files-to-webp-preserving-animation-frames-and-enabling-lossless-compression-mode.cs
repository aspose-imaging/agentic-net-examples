using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\GifInput";
        string outputFolder = @"C:\Images\WebpOutput";

        try
        {
            // Ensure the output directory exists (creates if missing)
            Directory.CreateDirectory(outputFolder);

            // Process each GIF file in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder, "*.gif"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the corresponding output path with .webp extension
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF (including animation frames)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure WebP options for lossless compression
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true,
                        Quality = 100 // maximum quality for lossless
                    };

                    // Save as animated WebP preserving frames
                    image.Save(outputPath, webpOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a developer needs to convert a batch of animated GIFs to lossless WebP for faster web delivery while preserving all animation frames.
 * 2. When a developer wants to automate the migration of legacy GIF assets in a content management system to modern WebP format using C# and Aspose.Imaging to reduce bandwidth usage.
 * 3. When a developer is building a desktop tool that processes user‑uploaded GIFs and saves them as high‑quality lossless WebP files for archival purposes.
 * 4. When a developer must generate WebP versions of GIF advertisements for an ad‑network, ensuring the animation sequence remains intact and the compression is lossless.
 * 5. When a developer needs to integrate a scheduled job that scans a folder of GIF animations and outputs corresponding WebP files with maximum quality for use in mobile apps.
 */