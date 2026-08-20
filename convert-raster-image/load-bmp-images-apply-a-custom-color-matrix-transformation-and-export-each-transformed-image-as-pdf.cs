// HOW-TO: Convert BMP Images to PDF with Custom Color Matrix in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories (relative paths)
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output PDF path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    BmpImage bmp = image as BmpImage;
                    if (bmp == null)
                    {
                        // Skip non‑BMP files (should not happen due to filter)
                        continue;
                    }

                    // Cache image data if not already cached
                    if (!bmp.IsCached)
                    {
                        bmp.CacheData();
                    }

                    // Define the full image rectangle
                    var bounds = new Rectangle(0, 0, bmp.Width, bmp.Height);

                    // Load ARGB pixels
                    int[] pixels = bmp.LoadArgb32Pixels(bounds);

                    // Apply a custom color matrix transformation (example: color inversion)
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int argb = pixels[i];
                        int a = (argb >> 24) & 0xFF;
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;

                        // Invert colors
                        r = 255 - r;
                        g = 255 - g;
                        b = 255 - b;

                        pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                    }

                    // Save modified pixels back to the image
                    bmp.SaveArgb32Pixels(bounds, pixels);

                    // Export the transformed image as PDF
                    bmp.Save(outputPath, new PdfOptions());
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
 * 1. When you must batch‑convert legacy BMP graphics to PDF documents while applying a custom color matrix, such as inverting colors for printing or branding.
 * 2. When an application needs to generate PDF catalogs from BMP product images and programmatically adjust the color balance before embedding them.
 * 3. When a document‑automation workflow requires converting scanned BMP pages to PDF with a predefined color filter to improve readability or meet compliance standards.
 * 4. When a C# service processes user‑uploaded BMP pictures and stores them as PDF files with a custom color effect for archival or preview purposes.
 * 5. When you are building a reporting tool that transforms BMP charts using a color matrix and exports each chart as a PDF page for distribution.
 */
