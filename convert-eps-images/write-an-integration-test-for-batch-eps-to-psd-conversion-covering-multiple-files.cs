using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class BatchEpsToPsdTest
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\TestData\EpsFiles";
        string outputDirectory = @"C:\TestData\PsdOutputs";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .psd extension)
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".psd");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EPS image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PSD save options (default settings)
                    var psdOptions = new PsdOptions
                    {
                        // Example: set compression method to RLE
                        CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                        // Example: set color mode to Grayscale
                        ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Grayscale
                    };

                    // Save as PSD
                    image.Save(outputPath, psdOptions);
                }

                // Verify that the PSD file was created
                if (File.Exists(outputPath))
                {
                    Console.WriteLine($"Successfully converted: {inputPath} -> {outputPath}");
                }
                else
                {
                    Console.Error.WriteLine($"Conversion failed for: {inputPath}");
                }
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
 * 1. When a graphic design studio needs to batch‑convert legacy EPS vector artwork into editable PSD files for Photoshop workflows.
 * 2. When an automated build pipeline must generate PSD previews from EPS assets to populate a web‑based digital asset management system.
 * 3. When a print‑to‑digital conversion service processes client‑supplied EPS logos in bulk and saves them as PSD files with grayscale color mode for pre‑press checks.
 * 4. When a migration script updates an e‑learning content repository by converting multiple EPS illustrations to PSD format with RLE compression to reduce file size.
 * 5. When a QA test suite validates that a collection of EPS files are correctly loaded and saved as PSD using Aspose.Imaging’s C# API across different directories.
 */