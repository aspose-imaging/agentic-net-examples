using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Get all BMP files in the input directory
        string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp", SearchOption.TopDirectoryOnly);

        foreach (string inputPath in bmpFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output file path with .webp extension
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".webp");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image and save it as lossless WebP
            using (Image image = Image.Load(inputPath))
            {
                WebPOptions options = new WebPOptions
                {
                    Lossless = true
                };
                image.Save(outputPath, options);
            }
        }
    }
}