// HOW-TO: Batch Rotate TIFF Images 90 Degrees And Convert To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the TIFF image
                using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
                {
                    // Rotate 90 degrees clockwise without flipping
                    tiffImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    // Build the output PNG path (same file name, .png extension)
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to automatically rotate a collection of scanned TIFF documents 90° and save them as PNGs for web display.
 * 2. When a photo‑processing pipeline must convert legacy TIFF files to PNG format while correcting orientation before uploading to a content management system.
 * 3. When a desktop application has to batch‑process medical imaging TIFFs, rotate them for proper viewing, and store the results as lossless PNGs.
 * 4. When you want to prepare a set of architectural blueprint TIFFs for inclusion in a PDF by rotating them and converting to PNG using C#.
 * 5. When an automated script must ensure all incoming TIFF assets are uniformly oriented and saved as PNGs for downstream AI image analysis.
 */
