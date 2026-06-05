using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Wrap the whole process to catch unexpected errors
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG export options for 24‑bit truecolor (8 bits per channel)
                PngOptions pngOptions = new PngOptions
                {
                    BitDepth = 8, // 8 bits per channel
                    ColorType = PngColorType.Truecolor, // 24‑bit RGB, no alpha
                    CompressionLevel = 9, // maximum compression (still lossless)
                    Progressive = true // optional: enable progressive loading
                };

                // Save the image as PNG with the specified options
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime exception without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to archive high‑resolution JPEG photographs as lossless 24‑bit PNG files using Aspose.Imaging for .NET to preserve exact color data.
 * 2. When an e‑commerce site generates product‑image thumbnails in PNG format with maximum compression to maintain true‑color fidelity while reducing bandwidth.
 * 3. When a medical imaging system exports scanned radiology images as true‑color PNGs via Aspose.Imaging to ensure pixel‑perfect, lossless storage for diagnostic analysis.
 * 4. When a web‑based graphics editor saves a user's edited canvas as a 24‑bit PNG with Aspose.Imaging so the image can be uploaded to a CDN without quality loss.
 * 5. When an automated reporting service converts high‑resolution charts into PNG files with 8‑bits per channel using Aspose.Imaging to embed lossless images in PDF reports.
 */