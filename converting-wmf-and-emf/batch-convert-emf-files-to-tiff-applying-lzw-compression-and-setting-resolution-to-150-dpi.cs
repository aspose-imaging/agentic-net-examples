using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Base directory of the application
        string baseDir = Directory.GetCurrentDirectory();

        // Input and output folders (relative to base directory)
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input folder exists; if not, create it and exit
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output folder exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all EMF files in the input folder
        string[] files = Directory.GetFiles(inputDirectory, "*.emf");

        foreach (var inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Build output file path with .tif extension
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".tif");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options: LZW compression and 150 DPI resolution
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.Compression = TiffCompressions.Lzw;
                    tiffOptions.ResolutionSettings = new ResolutionSetting(150, 150);

                    // Save as TIFF
                    image.Save(outputPath, tiffOptions);
                }
            }
        }
    }
}