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

        // Ensure directories exist
        Directory.CreateDirectory(inputDirectory);
        Directory.CreateDirectory(outputDirectory);

        // Get all TIFF files in the input directory
        string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

        foreach (string inputPath in tiffFiles)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Construct output file path with .png extension (APNG)
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            // Ensure output directory exists before saving
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image and save as APNG with 3 loops
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new ApngOptions { NumPlays = 3 });
            }
        }
    }
}