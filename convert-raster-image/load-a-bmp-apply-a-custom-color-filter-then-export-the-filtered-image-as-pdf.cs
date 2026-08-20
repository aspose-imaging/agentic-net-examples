// HOW-TO: Convert BMP to PDF with Inverted Colors Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Apply a simple custom color filter (invert colors)
                if (image is RasterImage raster)
                {
                    for (int y = 0; y < raster.Height; y++)
                    {
                        for (int x = 0; x < raster.Width; x++)
                        {
                            Color original = raster.GetPixel(x, y);
                            Color inverted = Color.FromArgb(
                                original.A,
                                255 - original.R,
                                255 - original.G,
                                255 - original.B);
                            raster.SetPixel(x, y, inverted);
                        }
                    }
                }

                // Export the filtered image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a printable PDF from a legacy BMP file while applying a negative‑image effect for visual emphasis.
 * 2. When an application must batch‑process scanned BMP documents, invert their colors for better contrast, and archive them as PDF files.
 * 3. When a web service receives BMP uploads, requires a color‑inverted preview, and returns the result as a PDF for client download.
 * 4. When a reporting tool creates PDF reports that include BMP graphics and wants to apply a custom color filter before embedding them.
 * 5. When a desktop utility converts user‑selected BMP images to PDF format and offers an option to invert colors for artistic or accessibility purposes.
 */
