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
            // Define batch items: input BMP, output PSD, desired compression method
            var batch = new (string inputPath, string outputPath, CompressionMethod compression)[]
            {
                (@"C:\Images\sample1.bmp", @"C:\Output\sample1_Raw.psd", CompressionMethod.Raw),
                (@"C:\Images\sample2.bmp", @"C:\Output\sample2_RLE.psd", CompressionMethod.RLE),
                // Add more entries as needed
            };

            foreach (var (inputPath, outputPath, compression) in batch)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PSD options
                    var psdOptions = new PsdOptions
                    {
                        CompressionMethod = compression,
                        // Optional: set other options such as ColorMode if needed
                        ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
                    };

                    // Save as PSD with specified compression
                    image.Save(outputPath, psdOptions);
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
 * 1. When a graphics pipeline needs to convert a large collection of legacy BMP assets into Photoshop‑compatible PSD files while applying specific compression (Raw or RLE) to each file for optimal file size and performance.
 * 2. When an e‑learning platform must automate the preparation of high‑resolution screenshots stored as BMPs into layered PSDs with different compression settings to meet varying bandwidth constraints for online delivery.
 * 3. When a digital archiving system processes scanned BMP images in bulk and saves them as PSDs with chosen compression methods to preserve image fidelity while reducing storage costs.
 * 4. When a game development studio wants to batch‑export character textures from BMP format to PSD, selecting Raw compression for texture maps that require lossless data and RLE for masks that benefit from run‑length encoding.
 * 5. When a print shop integrates a C# service that reads BMP proofs, converts them to PSD using Aspose.Imaging, and applies per‑file compression strategies to ensure compatibility with downstream Photoshop workflows.
 */