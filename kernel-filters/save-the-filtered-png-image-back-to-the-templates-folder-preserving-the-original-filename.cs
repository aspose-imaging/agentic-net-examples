using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths (preserve original filename)
        string inputPath = @"C:\Project\templates\sample.png";
        string outputPath = @"C:\Project\templates\sample.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with a filter type (e.g., Adaptive)
                PngOptions saveOptions = new PngOptions
                {
                    FilterType = PngFilterType.Adaptive
                };

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the filtered image back to the templates folder, preserving the filename
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
 * 1. When a developer needs to apply an Adaptive PNG filter to template images before publishing them on a website while preserving the original filenames.
 * 2. When an automated build script must compress PNG assets in a project's templates directory without changing their names to keep references intact.
 * 3. When a content management system updates its graphic templates by re‑saving PNG files with optimized filter settings using Aspose.Imaging for .NET.
 * 4. When a batch image processing tool processes user‑uploaded PNG logos stored in a templates folder and saves the filtered versions back to the same location.
 * 5. When a desktop application regenerates design mockups by loading PNG templates, applying a filter for better compression, and overwriting the original files to maintain version consistency.
 */