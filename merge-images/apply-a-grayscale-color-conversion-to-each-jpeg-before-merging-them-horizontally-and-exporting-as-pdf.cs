using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input/Output directory setup
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            // Collect sizes of grayscale JPEGs
            List<Size> sizes = new List<Size>();
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (JpegImage img = (JpegImage)Image.Load(filePath))
                {
                    img.Grayscale();
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            if (sizes.Count == 0)
            {
                Console.WriteLine("No images found to process.");
                return;
            }

            // Calculate canvas dimensions for horizontal merge
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (Size sz in sizes)
            {
                totalWidth += sz.Width;
                if (sz.Height > maxHeight) maxHeight = sz.Height;
            }

            // Create an unbound raster canvas
            using (RasterImage canvas = (RasterImage)Image.Create(new JpegOptions(), totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string filePath in files)
                {
                    using (JpegImage img = (JpegImage)Image.Load(filePath))
                    {
                        img.Grayscale();
                        Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Prepare output PDF path
                string outputPath = Path.Combine(outputDirectory, "merged.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save canvas as PDF
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    canvas.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to create a printable PDF brochure that shows product JPEG photos in grayscale side‑by‑side, this code converts each image, merges them horizontally, and exports the result as a PDF.
 * 2. When a developer wants to generate a compact PDF report of scanned receipts by first applying a grayscale conversion to each JPEG and then stitching them together horizontally for easy comparison.
 * 3. When a developer must prepare a medical imaging PDF that displays multiple X‑ray JPEGs in grayscale on a single horizontal canvas for quick radiologist review.
 * 4. When a developer is automating the production of an architectural portfolio PDF where each design JPEG is standardized to grayscale and combined horizontally for a consistent visual layout.
 * 5. When a developer is building an audit‑trail document that consolidates security‑camera snapshot JPEGs into a single grayscale PDF, merging the images horizontally to preserve chronological order.
 */