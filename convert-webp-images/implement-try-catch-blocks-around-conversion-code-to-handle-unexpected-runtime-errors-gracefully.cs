// HOW-TO: Convert JPEG to TIFF with Error Handling in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.jpg";
        string outputPath = "Output/sample.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Set TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive user‑uploaded JPEG photos as lossless TIFF files for long‑term storage while ensuring any file‑system or conversion errors are logged.
 * 2. When a desktop application must batch‑process images from a folder, converting each JPEG to TIFF and gracefully handling missing files or permission issues.
 * 3. When integrating Aspose.Imaging into a C# service that receives JPEG images via API and must return TIFF responses without crashing on unexpected runtime exceptions.
 * 4. When preparing images for print production, converting high‑resolution JPEGs to TIFF with proper error handling to avoid halting the workflow if a file is corrupted.
 * 5. When migrating legacy image assets to a TIFF‑based workflow and you need a simple C# script that validates paths, creates output directories, and catches conversion errors.
 */
