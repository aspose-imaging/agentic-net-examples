// HOW-TO: Invert Colors of PNG and Embed Into PDF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.png");
            string outputPath = Path.Combine("Output", "inverted.pdf");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel manipulation
                RasterImage raster = (RasterImage)image;
                raster.CacheData();

                // Load ARGB pixels
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

                // Invert colors (preserve alpha)
                for (int i = 0; i < pixels.Length; i++)
                {
                    int p = pixels[i];
                    int a = (p >> 24) & 0xFF;
                    int rgb = p & 0x00FFFFFF;
                    int invRgb = (~rgb) & 0x00FFFFFF;
                    pixels[i] = (a << 24) | invRgb;
                }

                // Save the modified pixels back to the image
                raster.SaveArgb32Pixels(raster.Bounds, pixels);

                // Embed the inverted image into a PDF
                var pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to create a negative‑style version of a PNG product photo and deliver it as a PDF using Aspose.Imaging in C#.
 * 2. When generating printable proof sheets that require the original PNG colors to be inverted and saved as a PDF via Aspose.Imaging.
 * 3. When building a document automation workflow that converts scanned PNG images into PDF files with a color‑inversion effect using Aspose.Imaging for .NET.
 * 4. When preparing marketing materials where the original PNG must be shown with reversed colors inside a PDF brochure created with Aspose.Imaging C# API.
 * 5. When implementing a batch process that reads PNG assets, applies an ARGB inversion, and saves the result directly as PDF for archival purposes with Aspose.Imaging.
 */
