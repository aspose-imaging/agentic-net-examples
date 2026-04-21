using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories relative to the current directory
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Get all BMP files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output file path with .webp extension
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image and save it as lossless WebP
            using (Image image = Image.Load(inputPath))
            {
                var options = new WebPOptions { Lossless = true };
                image.Save(outputPath, options);
            }
        }
    }
}