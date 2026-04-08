using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Set up base, input and output directories (atomic block as required)
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

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

        // Define target raster formats
        string[] targetFormats = new[] { "png", "jpg", "bmp" };

        foreach (string inputPath in files)
        {
            // Process only WMF files
            if (!Path.GetExtension(inputPath).Equals(".wmf", StringComparison.OrdinalIgnoreCase))
                continue;

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare vector rasterization options (common for all formats)
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                foreach (string fmt in targetFormats)
                {
                    // Build output file path
                    string outputPath = Path.Combine(outputDirectory,
                        $"{Path.GetFileNameWithoutExtension(inputPath)}.{fmt}");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Choose appropriate options based on format
                    ImageOptionsBase saveOptions;
                    switch (fmt)
                    {
                        case "png":
                            saveOptions = new PngOptions();
                            break;
                        case "jpg":
                            saveOptions = new JpegOptions();
                            break;
                        case "bmp":
                            saveOptions = new BmpOptions();
                            break;
                        default:
                            // Should never reach here
                            continue;
                    }

                    // Assign rasterization options
                    saveOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the rasterized image
                    image.Save(outputPath, saveOptions);
                }
            }
        }
    }
}