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
            // Hard‑coded input and output base directories
            string inputPath = @"C:\input\sample.eps";
            string outputBaseDir = @"C:\output";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output file name using a custom pattern
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_converted.psd";
            string outputPath = Path.Combine(outputBaseDir, outputFileName);

            // Ensure the output directory exists (creates it unconditionally)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Example: use RLE compression and grayscale color mode
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Grayscale,
                    // Optional: set version, channel bits, etc.
                    Version = 6,
                    ChannelBitsCount = 8,
                    ChannelsCount = 4
                };

                // Save the image as PSD with the specified options
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
 * 1. When a C# application must batch‑convert vector EPS artwork into Photoshop PSD files with a custom “_converted” suffix for downstream editing.
 * 2. When an automated workflow needs to verify the existence of an EPS source, create the output folder if missing, and save the result using Aspose.Imaging’s PsdOptions with RLE compression and grayscale mode.
 * 3. When a developer wants to enforce a consistent naming convention for converted images by extracting the original file name and appending a suffix before saving as PSD.
 * 4. When integrating Aspose.Imaging into a .NET service that processes incoming EPS files and outputs PSD files with specific version, channel bits, and channel count settings for compatibility with older Photoshop versions.
 * 5. When handling image conversion errors gracefully in a C# program by catching exceptions and logging missing files or save failures during EPS‑to‑PSD transformation.
 */