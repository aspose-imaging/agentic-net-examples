using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Base directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input and output directories exist
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
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
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Process only EMF or WMF files
            string extension = Path.GetExtension(inputPath).ToLowerInvariant();
            if (extension != ".emf" && extension != ".wmf")
            {
                continue;
            }

            // Determine output path
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG options with vector rasterization settings
                using (PngOptions pngOptions = new PngOptions())
                {
                    // Uniform DPI (e.g., 300x300)
                    pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                    // Configure vector rasterization
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    pngOptions.VectorRasterizationOptions = vectorOptions;

                    // Save as PNG
                    image.Save(outputPath, pngOptions);
                }
            }
        }
    }
}