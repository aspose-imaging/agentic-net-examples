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
            string inputDir = @"c:\input\";
            string outputDir = @"c:\output\";

            // Ensure output directory exists (in case it is used directly)
            Directory.CreateDirectory(outputDir);

            // Get all files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir);

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path with .png extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Calculate crop rectangle (5-pixel border on each side)
                    int cropX = 5;
                    int cropY = 5;
                    int cropWidth = Math.Max(0, image.Width - 2 * cropX);
                    int cropHeight = Math.Max(0, image.Height - 2 * cropY);
                    var cropBounds = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                    // Prepare PNG save options
                    var pngOptions = new PngOptions();

                    // Save the cropped portion as PNG
                    image.Save(outputPath, pngOptions, cropBounds);
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
 * 1. When a developer needs to batch convert a folder of JPEG or BMP files to PNG format while removing a 5‑pixel border from each image for consistent thumbnail generation on a website.
 * 2. When an application must preprocess scanned documents by cropping the outer margin and saving them as lossless PNGs for archival in a document management system.
 * 3. When a C# utility is required to prepare a set of product photos for e‑commerce platforms, ensuring all images have a uniform border crop and are stored in PNG to preserve transparency.
 * 4. When a machine‑learning pipeline demands a clean dataset of PNG images with identical dimensions, achieved by trimming a 5‑pixel edge from each source image during batch conversion.
 * 5. When a legacy media library needs to be migrated to a modern format, automatically converting assorted image files to PNG while discarding unwanted edge pixels to standardize the visual layout.
 */