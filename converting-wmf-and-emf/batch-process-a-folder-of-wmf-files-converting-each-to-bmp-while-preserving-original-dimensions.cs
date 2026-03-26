using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure the directories exist
        Directory.CreateDirectory(inputDirectory);
        Directory.CreateDirectory(outputDirectory);

        // Get all WMF files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.wmf");

        foreach (var file in files)
        {
            string inputPath = file;

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output BMP file path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".bmp");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image and save it as BMP preserving dimensions
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new BmpOptions());
            }
        }
    }
}