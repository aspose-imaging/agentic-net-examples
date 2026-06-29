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
            // Hard‑coded list of BMP files to process
            string[] inputFiles = {
                @"C:\Images\image1.bmp",
                @"C:\Images\image2.bmp"
            };

            // Corresponding compression methods for each file
            CompressionMethod[] compressionMethods = {
                CompressionMethod.RLE,   // Use RLE for the first file
                CompressionMethod.Raw    // Use no compression for the second file
            };

            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputPath = inputFiles[i];

                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PSD path (same folder, same name, .psd extension)
                string outputPath = Path.ChangeExtension(inputPath, ".psd");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PSD save options
                    var psdOptions = new PsdOptions
                    {
                        CompressionMethod = compressionMethods[i],
                        // Set a common color mode; adjust as needed
                        ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
                    };

                    // Save as PSD with the specified options
                    image.Save(outputPath, psdOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Any unexpected error is reported without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a design studio needs to convert a folder of legacy BMP assets into editable Photoshop PSD files while applying RLE compression to large, repetitive‑pattern images and leaving high‑detail images uncompressed for maximum quality.
 * 2. When an e‑learning platform automates the preparation of course graphics by batch‑processing BMP screenshots into PSD layers, selecting raw compression for color‑critical diagrams and RLE for simple icons to reduce file size.
 * 3. When a printing company migrates client‑provided BMP proofs to PSD format, using different compression methods per file to balance storage costs and preserve resolution for print‑ready artwork.
 * 4. When a game development team exports BMP texture maps to PSD for artists to edit, applying RLE compression to repetitive background textures and raw compression to character sprites that require lossless detail.
 * 5. When a digital archiving system ingests scanned BMP documents and stores them as PSD files, choosing RLE compression for text‑heavy pages and raw compression for high‑resolution photographic pages to optimize retrieval speed and fidelity.
 */