using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base, input and output directories
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

            // Get all EMF files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (var inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output PNG path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PNG export options
                    PngOptions pngOptions = new PngOptions
                    {
                        // Set 300 DPI resolution
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        // Use lossless compression (PNG is lossless; set compression level as desired)
                        PngCompressionLevel = PngCompressionLevel.ZipLevel0
                    };

                    // Set vector rasterization options for proper rendering of EMF
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = vectorOptions;

                    // Save as PNG
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}