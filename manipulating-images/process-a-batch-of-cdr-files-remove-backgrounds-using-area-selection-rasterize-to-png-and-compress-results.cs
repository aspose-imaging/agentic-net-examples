using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure output directory exists (will also handle subfolders)
            Directory.CreateDirectory(outputDirectory);

            // Get all CDR files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Remove background (using default settings)
                    cdrImage.RemoveBackground();

                    // Set up PNG rasterization options
                    var pngOptions = new PngOptions
                    {
                        // Optional: set compression level if needed
                        // CompressionLevel = PngCompressionLevel.BestCompression,

                        // Configure vector rasterization for CDR
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            // Example: preserve original size
                            PageWidth = 0,
                            PageHeight = 0,
                            // Optional: set background color for rasterized image
                            BackgroundColor = Color.White
                        }
                    };

                    // Save the rasterized PNG image
                    cdrImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}