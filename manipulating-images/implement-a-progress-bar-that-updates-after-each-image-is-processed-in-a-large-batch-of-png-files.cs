using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "InputImages";
        string outputDirectory = "OutputImages";

        // Get all PNG files in the input directory
        string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");
        int totalFiles = pngFiles.Length;

        if (totalFiles == 0)
        {
            Console.WriteLine("No PNG files found in the input directory.");
            return;
        }

        for (int i = 0; i < totalFiles; i++)
        {
            string inputPath = pngFiles[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Save using default PNG options
                var options = new PngOptions();
                image.Save(outputPath, options);
            }

            // Update progress bar
            int processed = i + 1;
            int percent = processed * 100 / totalFiles;
            Console.WriteLine($"Processed {processed}/{totalFiles} ({percent}%)");
        }

        Console.WriteLine("Batch processing completed.");
    }
}