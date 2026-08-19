// HOW-TO: Convert EPS to PSD with Custom Filename Pattern in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input EPS file path
            string inputPath = "sample.eps";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Custom output file name pattern: original name + "_converted.psd" in an "output" folder
            string outputPath = "output\\sample_converted.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Example settings – can be adjusted as needed
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Grayscale
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
 * 1. When you need to programmatically convert vector EPS artwork into Photoshop PSD files while applying grayscale RLE compression for downstream editing.
 * 2. When an automated workflow must generate PSD versions of EPS logos and store them in a dedicated output folder with a consistent “_converted” naming convention.
 * 3. When integrating Aspose.Imaging into a C# application to transform EPS illustrations into PSD layers for further manipulation in Adobe Photoshop.
 * 4. When building a batch processing tool that reads EPS files, applies specific PSD options, and saves the results using a custom file‑name pattern to avoid overwriting originals.
 * 5. When creating a server‑side service that receives EPS uploads, converts them to PSD format with grayscale color mode, and saves the output to a predefined directory structure.
 */
