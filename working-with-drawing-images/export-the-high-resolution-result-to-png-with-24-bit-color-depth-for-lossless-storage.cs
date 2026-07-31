using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options for 24‑bit truecolor (lossless)
                PngOptions pngOptions = new PngOptions
                {
                    // Truecolor = 24‑bit (8 bits per channel, no alpha)
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.Truecolor,
                    BitDepth = 8,
                    // Optional: set a high resolution (e.g., 300 DPI) for high‑resolution output
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                // Save the image as PNG using the specified options
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer must convert user‑uploaded JPEG photos to lossless 24‑bit PNG files for archival storage while preserving 300 DPI resolution.
 * 2. When an e‑commerce platform needs to generate high‑resolution product images in PNG format to ensure crisp display on retina screens without introducing compression artifacts.
 * 3. When a medical imaging application requires exporting scanned documents as true‑color PNGs to meet regulatory standards for lossless image preservation.
 * 4. When a desktop publishing tool automates the batch conversion of source JPEG assets into 24‑bit PNGs for print‑ready PDFs that demand exact color fidelity.
 * 5. When a GIS system prepares map tiles by loading JPEG source maps and saving them as high‑resolution PNGs with 8‑bit per channel color depth for seamless web rendering.
 */