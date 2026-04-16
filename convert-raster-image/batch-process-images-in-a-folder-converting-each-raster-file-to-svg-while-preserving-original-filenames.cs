using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories relative to the current directory
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure the output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files from the input directory
        string[] files = Directory.GetFiles(inputDirectory);

        // Supported raster extensions
        string[] rasterExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff", ".webp" };

        foreach (string inputPath in files)
        {
            // Verify the file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Process only supported raster files
            string ext = Path.GetExtension(inputPath).ToLowerInvariant();
            if (Array.IndexOf(rasterExtensions, ext) < 0)
            {
                continue; // Skip non‑raster files
            }

            // Build the output SVG path preserving the original filename
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image and convert to SVG
            using (Image image = Image.Load(inputPath))
            {
                using (SvgOptions options = new SvgOptions())
                {
                    // Set rasterization options to match the source image size
                    options.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Save as SVG
                    image.Save(outputPath, options);
                }
            }
        }
    }
}