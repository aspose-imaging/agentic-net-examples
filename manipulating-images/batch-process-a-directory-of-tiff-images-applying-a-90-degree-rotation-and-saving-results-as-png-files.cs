using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDir = "InputTiff";
        string outputDir = "OutputPng";

        // Ensure input directory exists
        if (!Directory.Exists(inputDir))
        {
            Directory.CreateDirectory(inputDir);
            Console.WriteLine($"Input directory created at: {inputDir}. Add TIFF files and rerun.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Get all files in the input directory
        string[] allFiles = Directory.GetFiles(inputDir);
        foreach (string filePath in allFiles)
        {
            // Process only .tif and .tiff files
            string ext = Path.GetExtension(filePath).ToLowerInvariant();
            if (ext != ".tif" && ext != ".tiff")
                continue;

            // Verify input file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Prepare output file path
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(filePath) + ".png");

            // Ensure output directory exists for this file
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load TIFF, rotate, and save as PNG
            using (TiffImage tiffImage = (TiffImage)Image.Load(filePath))
            {
                tiffImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                tiffImage.Save(outputPath, new PngOptions());
            }
        }
    }
}