using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputTiff";
        string outputDirectory = @"C:\OutputApng";

        // Validate input directory
        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine($"Input directory does not exist: {inputDirectory}");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all TIFF files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.tif");
        foreach (var file in files)
        {
            // Verify the input file exists
            if (!File.Exists(file))
            {
                Console.Error.WriteLine($"File not found: {file}");
                return;
            }

            // Build the output file path with .png extension (APNG)
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".png");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image and save as APNG with 3 loops
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(file))
            {
                image.Save(outputPath, new ApngOptions { NumPlays = 3 });
            }
        }
    }
}