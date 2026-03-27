using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input and output directories (relative to current directory)
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input and output directories exist
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add TIFF files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string inputPath in files)
        {
            // Validate that the file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Process only TIFF files
            string extension = Path.GetExtension(inputPath).ToLowerInvariant();
            if (extension != ".tif" && extension != ".tiff")
            {
                continue;
            }

            // Build output file name with timestamp suffix
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory exists (unconditional as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image and save as WebP
            using (Image image = Image.Load(inputPath))
            {
                using (WebPOptions options = new WebPOptions())
                {
                    image.Save(outputPath, options);
                }
            }

            Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
        }
    }
}