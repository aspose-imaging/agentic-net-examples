using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try/catch to handle unexpected errors gracefully
        try
        {
            // Hard‑coded input and output directories
            string inputDir = @"C:\temp\input\";
            string outputDir = @"C:\temp\output\";

            // List of BMP files to process
            string[] bmpFiles = new string[]
            {
                "image1.bmp",
                "image2.bmp",
                "image3.bmp"
            };

            // Corresponding PSD compression methods for each file
            CompressionMethod[] compressionMethods = new CompressionMethod[]
            {
                CompressionMethod.RLE,   // image1.bmp -> RLE compression
                CompressionMethod.Raw,   // image2.bmp -> No compression
                CompressionMethod.RLE    // image3.bmp -> RLE compression
            };

            // Process each file
            for (int i = 0; i < bmpFiles.Length; i++)
            {
                // Build full input path
                string inputPath = Path.Combine(inputDir, bmpFiles[i]);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build full output path (same name with .psd extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(bmpFiles[i]) + ".psd");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PSD save options
                    var psdOptions = new PsdOptions
                    {
                        CompressionMethod = compressionMethods[i],
                        // Optional: set a common color mode (e.g., RGB)
                        ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
                    };

                    // Save as PSD using the specified compression method
                    image.Save(outputPath, psdOptions);
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}' with {compressionMethods[i]} compression.");
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected error without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a graphics pipeline needs to convert a batch of legacy BMP assets into Photoshop‑compatible PSD files while applying specific compression methods per image.
 * 2. When an automated build script must generate layered PSD mockups from BMP screenshots, using RLE compression for smaller files and raw compression for loss‑less preservation.
 * 3. When a digital asset management system requires nightly conversion of newly uploaded BMP textures to PSD format with per‑file compression settings to optimize storage.
 * 4. When a Windows desktop application processes user‑selected BMP images and saves them as PSD files with different compression algorithms to meet varying quality and file‑size requirements.
 * 5. When a cloud‑based image processing service needs to read BMP files from a directory, convert them to PSD using Aspose.Imaging for .NET, and apply distinct compression methods before uploading the results.
 */