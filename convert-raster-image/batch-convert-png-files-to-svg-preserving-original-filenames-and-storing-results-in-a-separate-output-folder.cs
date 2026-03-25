using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "C:\\InputPngs";
        string outputDirectory = "C:\\OutputSvgs";

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

        // Get all PNG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.png");

        foreach (string inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output file path with .svg extension
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

            // Ensure output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PNG image and save as SVG
            using (Image image = Image.Load(inputPath))
            {
                using (SvgOptions saveOptions = new SvgOptions())
                {
                    saveOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    image.Save(outputPath, saveOptions);
                }
            }
        }
    }
}