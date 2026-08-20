// HOW-TO: Apply Ordered Dithering to PSD and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.psd";
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Perform ordered (threshold) dithering on raster images
                if (image is RasterImage rasterImage)
                {
                    // Use 4‑bit palette for dithering (adjust as needed)
                    rasterImage.Dither(DitheringMethod.ThresholdDithering, 4);
                }

                // Save the result as PDF
                image.Save(outputPath);
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
 * 1. When a designer needs to convert high‑resolution Photoshop files into printable PDFs with reduced banding by applying ordered dithering.
 * 2. When an automated workflow must batch‑process PSD assets, apply threshold dithering to limit colors, and generate PDF previews for web catalogs.
 * 3. When a C# application has to preserve the visual fidelity of a PSD while reducing file size for archival PDFs using a 4‑bit palette.
 * 4. When a server‑side service converts user‑uploaded PSD files to PDF documents and wants to improve contrast on low‑color‑depth displays via dithering.
 * 5. When integrating Aspose.Imaging into a .NET project to transform raster PSD layers into PDF format with consistent ordered dithering across all pages.
 */
