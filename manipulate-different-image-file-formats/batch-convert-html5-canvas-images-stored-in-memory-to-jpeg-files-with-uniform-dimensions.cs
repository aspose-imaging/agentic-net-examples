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

        // Get all HTML5 Canvas files (assuming .html extension)
        string[] inputFiles = Directory.GetFiles(inputDirectory, "*.html");

        // Uniform dimensions for all output JPEGs
        const int targetWidth = 800;
        const int targetHeight = 600;

        foreach (string inputPath in inputFiles)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to uniform dimensions
                image.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

                // Set JPEG save options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
    }
}