using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Define base directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Validate input directory
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

        // Get all SVG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.svg");

        foreach (string inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".png");

            // Ensure output directory for the file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to monochrome PNG
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PNG options for monochrome output
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ColorType = PngColorType.Grayscale,
                    BitDepth = 1
                };

                // Save the rasterized PNG
                image.Save(outputPath, pngOptions);
            }
        }
    }
}