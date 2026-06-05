using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

                // Determine output path
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image as RasterImage, embed signature, and save
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Embed digital signature with shared password
                    image.EmbedDigitalSignature("sharedPassword");

                    // Prepare PNG save options bound to the output file
                    PngOptions saveOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    // Save the signed image
                    image.Save(outputPath, saveOptions);
                }

                // Log success
                Console.WriteLine($"Signed: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}