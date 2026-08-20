// HOW-TO: Invert Colors of a PNG and Save as PDF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded relative input and output paths
            string inputPath = "Input/sample.png";
            string outputPath = "Output/inverted.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and process it
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel-level operations
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                int width = raster.Width;
                int height = raster.Height;

                // Invert colors pixel by pixel
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int argb = raster.GetArgb32Pixel(x, y);
                        int a = (argb >> 24) & 0xFF;
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;

                        // Invert RGB components
                        r = 255 - r;
                        g = 255 - g;
                        b = 255 - b;

                        int invertedArgb = (a << 24) | (r << 16) | (g << 8) | b;
                        raster.SetArgb32Pixel(x, y, invertedArgb);
                    }
                }

                // Save the processed image as PDF
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
 * 1. When you need to create a negative version of a raster image for printing or visual effects and output it directly as a PDF.
 * 2. When a web application must generate PDF previews with inverted colors for a dark‑mode theme without using external image editors.
 * 3. When you want to process scanned documents to highlight details by inverting their colors before archiving them as PDF files.
 * 4. When an automated batch job has to convert a folder of PNG files into PDF reports with color inversion applied to each image.
 * 5. When a digital‑signage system requires on‑the‑fly color‑inverted images saved as PDFs for devices that only support PDF rendering.
 */
