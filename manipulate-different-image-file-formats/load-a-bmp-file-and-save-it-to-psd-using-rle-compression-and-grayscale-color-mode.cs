// HOW-TO: Convert BMP to Grayscale PSD with RLE Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.psd";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options: RLE compression and Grayscale color mode
                var psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Grayscale
                };

                // Save the image as PSD with the specified options
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
 * 1. When you need to prepare a BMP image for Photoshop workflows that require a grayscale PSD with lossless RLE compression.
 * 2. When automating batch conversion of legacy BMP assets into PSD files for designers while preserving a smaller file size.
 * 3. When creating print‑ready or thumbnail files where the source is BMP but the target must be a grayscale PSD for compatibility.
 * 4. When integrating image processing into a .NET application that must output PSD files with specific compression to meet Photoshop import standards.
 * 5. When migrating a catalog of BMP images to a grayscale PSD format to reduce color information and ensure consistent layering in Photoshop.
 */
