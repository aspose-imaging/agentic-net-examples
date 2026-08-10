// HOW-TO: Set Image Resolution When Converting BMP to PSD in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.psd";

        try
        {
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
                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Set desired resolution (e.g., 300 DPI)
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0),

                    // Optional: set compression method and color mode
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb
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
 * 1. When you need to generate high‑resolution PSD files from bitmap assets for professional printing.
 * 2. When you must preserve image quality by setting a specific DPI before saving to Photoshop format.
 * 3. When an automated pipeline converts scanned images to PSD and requires consistent 300 DPI output.
 * 4. When you are building a C# application that exports layered designs with RLE compression and a defined color mode.
 * 5. When you need to ensure the output PSD matches the resolution requirements of downstream graphic‑editing tools.
 */
