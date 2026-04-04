using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Get all PNG files in the input folder
        string[] files = Directory.GetFiles(inputDirectory, "*.png");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output BMP file path
            string outputPath = Path.Combine(outputDirectory,
                Path.GetFileNameWithoutExtension(inputPath) + ".bmp");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, resize, and save as BMP
            using (Image image = Image.Load(inputPath))
            {
                image.Resize(640, 480);
                image.Save(outputPath, new BmpOptions());
            }
        }
    }
}