// HOW-TO: Batch Convert Multiple EPS Files to Grayscale PSD with RLE Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Test\EpsBatch\Input";
            string outputFolder = @"C:\Test\EpsBatch\Output";

            // Ensure the output root directory exists
            Directory.CreateDirectory(outputFolder);

            // Retrieve all EPS files from the input directory
            string[] epsFiles = Directory.GetFiles(inputFolder, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the corresponding PSD output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".psd");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Configure PSD save options (example: RLE compression, Grayscale mode)
                    var psdOptions = new PsdOptions
                    {
                        CompressionMethod = CompressionMethod.RLE,
                        ColorMode = ColorModes.Grayscale
                    };

                    // Save the image as PSD
                    image.Save(outputPath, psdOptions);
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

/*
 * Real-World Use Cases:
 * 1. When you need to automatically convert a folder of vector EPS artwork into Photoshop PSD files for further editing in a design pipeline.
 * 2. When you want to ensure all converted PSDs use grayscale color mode and RLE compression to reduce file size while preserving quality.
 * 3. When you are building an integration test to verify that batch EPS‑to‑PSD conversion works correctly across multiple files in a CI environment.
 * 4. When you need to process user‑uploaded EPS files on a server and store the resulting PSDs in a structured output directory.
 * 5. When you are migrating legacy EPS assets to PSD format for compatibility with modern Adobe Photoshop workflows.
 */
