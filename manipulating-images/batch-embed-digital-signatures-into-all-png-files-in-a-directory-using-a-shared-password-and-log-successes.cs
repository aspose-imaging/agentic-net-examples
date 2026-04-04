using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Shared password for digital signature
        string password = "SharedPassword123";

        // Get all PNG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.png");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine the output file path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, embed the digital signature, and save
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access EmbedDigitalSignature
                RasterImage raster = (RasterImage)image;
                raster.EmbedDigitalSignature(password);

                // Prepare PNG save options with a bound source
                using (var options = new PngOptions())
                {
                    options.Source = new FileCreateSource(outputPath, false);
                    raster.Save(outputPath, options);
                }
            }

            // Log successful processing
            Console.WriteLine($"Signed and saved: {outputPath}");
        }
    }
}