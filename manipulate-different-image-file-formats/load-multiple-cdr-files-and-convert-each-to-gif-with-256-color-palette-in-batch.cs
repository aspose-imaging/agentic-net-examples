using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputCdrFiles";
            string outputDirectory = @"C:\OutputGifs";

            // Ensure the output directory exists (will also handle subfolders)
            Directory.CreateDirectory(outputDirectory);

            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output GIF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure GIF save options for 256‑color palette
                var gifOptions = new GifOptions
                {
                    // 7 means (bits per pixel - 1) => 8 bits => 256 colors
                    ColorResolution = 7,
                    DoPaletteCorrection = true
                };

                // Load the CDR image and save as GIF
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, gifOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}