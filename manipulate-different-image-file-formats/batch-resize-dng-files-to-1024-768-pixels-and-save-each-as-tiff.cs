// HOW-TO: Batch Resize DNG Images to 1024x768 and Convert to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputDng\";
            string outputDir = @"C:\OutputTiff\";

            // Get all DNG files in the input directory
            string[] dngFiles = Directory.GetFiles(inputDir, "*.dng");

            foreach (string inputPath in dngFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .tif extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".tif");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DNG image with default load options
                using (Image dngImage = Image.Load(inputPath, new DngLoadOptions()))
                {
                    // Resize to 1024x768
                    dngImage.Resize(1024, 768);

                    // Prepare TIFF save options
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                    // Save as TIFF
                    dngImage.Save(outputPath, tiffOptions);
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
 * 1. When a photographer needs to downscale raw DNG photos for quick preview and archive them as TIFF files.
 * 2. When a digital asset management system must process a folder of DNG files and store them in a universally supported TIFF format at a fixed resolution.
 * 3. When a batch conversion tool is required to prepare raw images for printing workflows that accept only 1024×768 TIFF files.
 * 4. When an automated script must ensure all incoming DNG files are resized and saved as TIFF to reduce storage size while preserving lossless quality.
 * 5. When a C# application needs to convert raw camera files to TIFF for compatibility with legacy image processing software.
 */
