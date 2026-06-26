using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.psd";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Grayscale
                };

                // Save the image as PSD
                image.Save(outputPath, psdOptions);
            }

            // Verify that the PSD file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("PSD file created successfully.");
            }
            else
            {
                Console.Error.WriteLine("Failed to create PSD file.");
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
 * 1. When an automated graphics pipeline must convert legacy BMP assets to Photoshop‑compatible PSD files with RLE compression and confirm the conversion succeeded before publishing.
 * 2. When a desktop application needs to batch‑process user‑uploaded bitmap images, save them as grayscale PSDs, and verify the output files exist to avoid missing assets.
 * 3. When a CI/CD build script validates that image resources are correctly transformed from BMP to PSD format as part of a pre‑release quality check.
 * 4. When a server‑side service generates PSD mockups from BMP templates and must ensure the generated files are stored in the target directory without errors.
 * 5. When a migration tool moves image data from an old file system to a new one, converting each BMP to PSD and checking file existence to guarantee data integrity.
 */