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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.psd";

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
                // Configure PSD saving options with RLE compression to reduce file size
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE
                    // Additional options (e.g., ColorMode) can be set here if needed
                };

                // Save the image as PSD using the configured options
                image.Save(outputPath, psdOptions);
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
 * 1. When a graphic design workflow requires converting high‑resolution BMP assets to PSD files for Photoshop while keeping the file size low for faster network transfer, a developer can use this code with RLE compression.
 * 2. When an automated batch‑processing service generates PSD previews from uploaded images and must stay within storage quotas, the code helps reduce each PSD’s footprint.
 * 3. When a cloud‑based collaboration platform needs to store user‑edited layers as PSDs but wants to minimize bandwidth for real‑time syncing, applying the CompressionMethod.RLE option is essential.
 * 4. When a digital asset management system archives legacy bitmap files as PSDs for future editing and must keep archive size manageable, this snippet provides the necessary compression.
 * 5. When a CI/CD pipeline validates that exported PSDs meet size constraints before publishing to a design repository, developers can employ this code to enforce RLE compression during the save operation.
 */