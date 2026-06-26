using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\sample.psd";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options
                var psdOptions = new PsdOptions
                {
                    // Use RLE compression to keep file size reasonable
                    CompressionMethod = CompressionMethod.RLE,
                    // Preserve full color information
                    ColorMode = ColorModes.Rgb,
                    // Keep default version (6) and other defaults
                };

                // Save as PSD; layers from the EPS (if any) are preserved automatically
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
 * 1. When a graphic designer needs to convert vector EPS artwork into a layered PSD file so that Photoshop can edit each element separately using C# and Aspose.Imaging.
 * 2. When an automated build pipeline must batch‑process EPS logos and output PSD files with RLE compression and RGB color mode for downstream marketing assets.
 * 3. When a web service receives user‑uploaded EPS files and must preserve their layers while saving them as PSDs for a cloud‑based Photoshop editing workflow.
 * 4. When a legacy printing system requires EPS files to be transformed into PSD format with preserved layers to maintain editability in modern design tools.
 * 5. When a C# application needs to validate the existence of an EPS source, create the output directory, and safely convert the file to PSD while handling exceptions.
 */