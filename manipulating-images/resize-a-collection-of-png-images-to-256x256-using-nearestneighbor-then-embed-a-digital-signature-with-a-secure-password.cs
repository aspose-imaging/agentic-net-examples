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
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
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
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_resized.png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists for the file
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, resize, embed signature, and save
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Resize to 256x256 using default NearestNeighbourResample
                    image.Resize(256, 256);

                    // Embed digital signature with a secure password
                    image.EmbedDigitalSignature("secure123");

                    // Save the processed image
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}