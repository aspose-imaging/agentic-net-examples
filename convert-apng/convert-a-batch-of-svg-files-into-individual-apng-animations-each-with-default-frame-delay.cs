using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputSvgs";
        string outputDirectory = @"C:\OutputApngs";

        // Ensure the output root directory exists
        Directory.CreateDirectory(outputDirectory);

        // Retrieve all SVG files in the input directory
        string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

        foreach (string inputPath in svgFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output file path (same name with .png extension for APNG)
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            // Ensure the directory for the output file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Save as APNG using default frame delay
                image.Save(outputPath, new ApngOptions());
            }
        }
    }
}