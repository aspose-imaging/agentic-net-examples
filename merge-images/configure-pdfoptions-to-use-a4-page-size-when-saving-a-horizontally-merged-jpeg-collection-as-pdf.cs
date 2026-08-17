// HOW-TO: Save Horizontally Merged JPEG Images As A4 PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input JPEG files (hardcoded relative paths)
            string[] inputPaths = new string[]
            {
                "Input\\image1.jpg",
                "Input\\image2.jpg",
                "Input\\image3.jpg"
            };

            // Validate each input file
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Output PDF file (hardcoded relative path)
            string outputPath = "Output\\merged.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Create a raster canvas (no source bound)
            JpegOptions canvasOptions = new JpegOptions();
            using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Configure PDF options with A4 page size (595x842 points)
                PdfOptions pdfOptions = new PdfOptions
                {
                    PageSize = new SizeF(595f, 842f)
                };

                // Save the merged canvas as PDF
                canvas.Save(outputPath, pdfOptions);
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
 * 1. When you need to combine multiple product photos placed side‑by‑side into a single A4‑sized PDF brochure for printing or distribution.
 * 2. When an application must generate a printable catalog page by stitching landscape‑oriented JPEG screenshots into one PDF document.
 * 3. When a reporting tool has to create an A4 PDF report that merges several scanned receipts horizontally for audit review.
 * 4. When a web service converts a set of JPEG banners into a single A4 PDF flyer without losing image quality.
 * 5. When an automated workflow assembles daily camera snapshots into an A4 PDF sheet for archival or email attachment.
 */
