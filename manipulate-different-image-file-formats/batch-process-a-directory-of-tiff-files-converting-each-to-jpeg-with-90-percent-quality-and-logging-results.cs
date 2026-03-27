using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Collect all TIFF files (both .tif and .tiff)
        string[] tifFiles = Directory.GetFiles(inputDirectory, "*.tif");
        string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tiff");
        List<string> allFiles = new List<string>();
        allFiles.AddRange(tifFiles);
        allFiles.AddRange(tiffFiles);

        foreach (string inputPath in allFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path with .jpg extension
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure JPEG options with 90% quality
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.Quality = 90;

                // Load the TIFF image and save as JPEG
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, jpegOptions);
                }
            }

            Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
        }
    }
}