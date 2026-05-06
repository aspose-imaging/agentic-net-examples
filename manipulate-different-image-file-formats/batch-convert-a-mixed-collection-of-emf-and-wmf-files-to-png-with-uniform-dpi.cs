using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "Input";
            string outputDir = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all EMF and WMF files
            var files = Directory.GetFiles(inputDir, "*.*")
                .Where(f => f.EndsWith(".emf", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (var inputPath in files)
            {
                // Check input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the vector image (EMF or WMF)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PNG options with uniform DPI
                    PngOptions pngOptions = new PngOptions
                    {
                        // Set DPI to 300x300
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        // Rasterization options for vector formats
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageSize = image.Size,
                            BackgroundColor = Color.White
                        }
                    };

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