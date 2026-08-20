// HOW-TO: Apply Gamma Correction to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.tif";
        string outputPath = @"c:\temp\sample.AdjustGamma.png";

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

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access AdjustGamma
                TiffImage tiffImage = (TiffImage)image;

                // Apply gamma correction (same coefficient for all channels)
                tiffImage.AdjustGamma(1.2f);

                // Save the adjusted image as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to brighten a scanned TIFF document by adjusting its gamma before converting it to a web‑friendly PNG format.
 * 2. When a photo‑editing application must correct the luminance of high‑resolution TIFF images and export them as lossless PNGs for further processing.
 * 3. When an automated batch job has to improve the visual contrast of TIFF graphics and store the results as PNG files for use in mobile apps.
 * 4. When integrating Aspose.Imaging into a C# service that receives TIFF uploads, applies a 1.2 gamma correction, and returns PNG thumbnails to clients.
 * 5. When preparing archival TIFF scans for online publishing, you want to apply a subtle gamma boost and convert them to PNG to reduce file size while preserving quality.
 */
