using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        try
        {
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

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Check if the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for processing
                    RasterImage raster = (RasterImage)image;

                    // Verify minimum size requirement (8x8)
                    if (raster.Width < 8 || raster.Height < 8)
                    {
                        Console.WriteLine($"Skipping {inputPath}: image size is smaller than 8x8 pixels.");
                        continue;
                    }

                    // Embed digital signature with a valid password
                    raster.EmbedDigitalSignature("secure123");

                    // Save the signed image
                    raster.Save(outputPath);
                }

                Console.WriteLine($"Processed and saved: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}