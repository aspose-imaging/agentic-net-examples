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
            // Hardcoded list of TIFF input files
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input1.tif",
                @"C:\Images\Input2.tif",
                @"C:\Images\Input3.tif"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Images\WebPOutput";

            // Ensure the output directory exists once (unconditional as per rule)
            Directory.CreateDirectory(outputDirectory);

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .webp extension
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Set WebP options with quality 90
                    var webpOptions = new WebPOptions
                    {
                        Quality = 90
                    };

                    // Save as WebP
                    image.Save(outputPath, webpOptions);
                }

                // Log successful conversion
                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
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
 * 1. When a developer needs to batch‑convert a collection of high‑resolution TIFF scans to WebP images with a quality setting of 90 for faster web loading, this code provides a simple C# solution.
 * 2. When an e‑commerce platform must automatically generate lightweight WebP thumbnails from product TIFF photos stored on a server, the script can process each file and log the results.
 * 3. When a digital archiving system requires periodic conversion of TIFF documents to WebP to reduce storage costs while maintaining visual fidelity, the code handles the file existence checks and directory creation.
 * 4. When a content management workflow demands that newly uploaded TIFF assets be instantly transformed into WebP format for responsive design, this C# loop performs the conversion and reports success.
 * 5. When a developer is building a command‑line utility to migrate legacy TIFF image libraries to modern WebP format with consistent quality and error handling, the example demonstrates the necessary image loading, option setting, and logging steps.
 */