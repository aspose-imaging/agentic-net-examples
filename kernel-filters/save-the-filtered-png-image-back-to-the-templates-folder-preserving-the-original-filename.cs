using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths (preserve original filename)
        string inputPath = @"C:\Project\templates\sample.png";
        string outputPath = @"C:\Project\templates\sample.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options (example: use Adaptive filter)
                PngOptions saveOptions = new PngOptions
                {
                    FilterType = PngFilterType.Adaptive,
                    // Additional options can be set here if needed
                };

                // Save the image back to the templates folder, preserving the filename
                image.Save(outputPath, saveOptions);
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
 * 1. When a web application needs to automatically optimize PNG assets in its templates directory by applying an adaptive filter before deployment.
 * 2. When a desktop publishing tool must re‑save user‑edited PNG templates with lossless compression settings while keeping the original file names.
 * 3. When a batch processing script updates product catalog images stored in a templates folder, ensuring each PNG is filtered and overwritten in place.
 * 4. When a CI/CD pipeline validates and normalizes PNG resources in a project's template folder to meet branding guidelines without changing file paths.
 * 5. When a content management system programmatically refreshes cached PNG thumbnails by re‑saving them with Aspose.Imaging filter options while preserving filenames.
 */