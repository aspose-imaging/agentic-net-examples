using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all JPEG2000 files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.jp2");

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build corresponding output path with .jpg extension
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".jpg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load JPEG2000 image and save as JPEG with quality 80
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 80
                    };
                    jpeg2000Image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to batch convert a collection of JPEG2000 (.jp2) medical or satellite images to standard JPEG files for web display while maintaining a consistent 80% compression quality.
 * 2. When an image‑processing pipeline must automatically transform high‑resolution JPEG2000 assets stored in a folder into smaller JPEG files for faster loading in a mobile app.
 * 3. When a migration script is required to replace legacy JPEG2000 assets with JPEG equivalents in a content‑management system, preserving directory structure and applying uniform quality settings.
 * 4. When a C# utility is needed to generate JPEG thumbnails from a batch of JPEG2000 source images for e‑commerce product catalogs, ensuring each thumbnail uses the same 80% quality level.
 * 5. When a developer wants to integrate a scheduled job that scans an input directory, converts all JPEG2000 files to JPEG with a fixed compression ratio, and saves them to an output folder for archival purposes.
 */