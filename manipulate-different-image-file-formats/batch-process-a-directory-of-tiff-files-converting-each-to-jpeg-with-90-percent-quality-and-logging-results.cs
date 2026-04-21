using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        foreach (string inputPath in files)
        {
            // Process only TIFF files
            string ext = Path.GetExtension(inputPath);
            if (!ext.Equals(".tif", StringComparison.OrdinalIgnoreCase) &&
                !ext.Equals(".tiff", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output path with .jpg extension
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image and convert to JPEG
            using (Image image = Image.Load(inputPath))
            using (JpegOptions jpegOptions = new JpegOptions())
            {
                jpegOptions.Quality = 90;
                image.Save(outputPath, jpegOptions);
            }

            Console.WriteLine($"Converted {inputPath} to {outputPath}");
        }
    }
}