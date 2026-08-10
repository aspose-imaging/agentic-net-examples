// HOW-TO: Convert DNG RAW Image to Lossless JPEG2000 with Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.dng";
            string outputPath = @"c:\temp\output.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image
            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;

                // Configure JPEG2000 options for lossless compression and metadata preservation
                Jpeg2000Options jpeg2000Options = new Jpeg2000Options
                {
                    Irreversible = false,          // lossless DWT 5-3
                    KeepMetadata = true            // preserve original metadata
                };

                // Save as JPEG2000
                dngImage.Save(outputPath, jpeg2000Options);
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
 * 1. When you need to archive raw camera photos in a space-efficient, lossless format while keeping EXIF and XMP data intact.
 * 2. When a digital asset management system requires JPEG2000 files for long-term preservation of DNG source images.
 * 3. When a medical imaging workflow converts RAW DNG scans to JPEG2000 for lossless storage and metadata compliance.
 * 4. When a web service generates thumbnails from DNG files and must deliver them as JPEG2000 without losing original metadata.
 * 5. When a batch processing script migrates a collection of DNG files to JPEG2000 using C# and Aspose.Imaging for consistent image quality.
 */
