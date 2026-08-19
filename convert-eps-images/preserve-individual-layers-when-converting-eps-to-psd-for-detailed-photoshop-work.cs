// HOW-TO: Convert EPS to PSD with Layer Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\sample.eps";
        string outputPath = @"C:\temp\sample.psd";

        try
        {
            // Verify that the EPS source file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options – default settings preserve layers
                var psdOptions = new PsdOptions
                {
                    // Example settings (optional, can be adjusted as needed)
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                    Version = 6
                };

                // Save as PSD, preserving layers
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a designer needs to import vector artwork from an EPS file into Photoshop while keeping each element as a separate layer for further editing.
 * 2. When an automated build process must batch‑convert EPS assets to PSD files so that downstream graphics pipelines can manipulate layers programmatically.
 * 3. When a web service receives EPS uploads and must deliver PSD versions that retain editable layers for client‑side Photoshop workflows.
 * 4. When a migration script moves legacy EPS resources into a Photoshop‑based asset library without flattening the artwork.
 * 5. When a C# application integrates Aspose.Imaging to preserve layer structure while converting EPS logos to PSD for high‑resolution print preparation.
 */
