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
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
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

            // Determine output BMP path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");

            // Ensure output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare vector rasterization options
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Prepare BMP options with 24-bit color depth
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    bmpOptions.BitsPerPixel = 24;
                    bmpOptions.VectorRasterizationOptions = vectorOptions;

                    // Save as BMP
                    image.Save(outputPath, bmpOptions);
                }
            }
        }
    }
}