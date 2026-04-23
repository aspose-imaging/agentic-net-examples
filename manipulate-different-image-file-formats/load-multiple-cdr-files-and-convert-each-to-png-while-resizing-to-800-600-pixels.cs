using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputCdr";
            string outputDir = @"C:\OutputPng";

            // List of CDR files to process
            string[] inputFiles = new string[]
            {
                Path.Combine(inputDir, "file1.cdr"),
                Path.Combine(inputDir, "file2.cdr")
                // Add more file paths as needed
            };

            foreach (var inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Resize to 800x600 pixels
                    cdrImage.Resize(800, 600);

                    // Prepare output file path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    cdrImage.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}