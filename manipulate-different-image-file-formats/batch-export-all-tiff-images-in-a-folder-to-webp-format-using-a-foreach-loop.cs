using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output directories (relative to the executable location)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Retrieve all files from the input directory
        string[] files = Directory.GetFiles(inputDirectory);

        foreach (string inputPath in files)
        {
            // Process only TIFF files
            string ext = Path.GetExtension(inputPath);
            if (!string.Equals(ext, ".tif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(ext, ".tiff", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Construct the output file path with .webp extension
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image and save it as WebP
            using (Image image = Image.Load(inputPath))
            {
                using (WebPOptions options = new WebPOptions())
                {
                    // Example option settings (adjust as needed)
                    options.Lossless = false;
                    options.Quality = 80f;

                    image.Save(outputPath, options);
                }
            }
        }
    }
}