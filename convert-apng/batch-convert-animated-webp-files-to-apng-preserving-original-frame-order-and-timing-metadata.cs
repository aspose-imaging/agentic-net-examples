using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "C:\\WebpInput";
            string outputDir = "C:\\ApngOutput";

            // Get all animated WebP files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name with .png extension)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the animated WebP image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as APNG, preserving original frame timing and metadata
                    var apngOptions = new ApngOptions
                    {
                        KeepMetadata = true // retain frame timing information
                    };
                    image.Save(outputPath, apngOptions);
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
 * 1. When a developer needs to migrate a library of animated WebP assets to APNG for better browser compatibility while preserving frame order and timing metadata.
 * 2. When an e‑learning platform wants to batch convert user‑uploaded animated WebP illustrations into APNG files for use in HTML5 slideshows without losing animation speed.
 * 3. When a game studio automates the conversion of animated WebP spritesheets into APNG textures for Unity, ensuring each frame’s delay is kept intact.
 * 4. When a digital marketing team processes a folder of promotional animated WebP banners into APNG format to embed in email newsletters that require PNG support.
 * 5. When a content management system runs a nightly job to transform newly added animated WebP icons into APNG files, maintaining original frame sequence and metadata for consistent UI rendering.
 */