// HOW-TO: Convert Multiple JPEGs to Grayscale and Merge Horizontally into PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input and output directories exist
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get JPEG files
            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                                      .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                  f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                                      .ToArray();

            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // First pass: collect sizes
            List<Size> sizes = new List<Size>();
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (JpegImage img = (JpegImage)Image.Load(file))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            int totalWidth = sizes.Sum(s => s.Width);
            int maxHeight = sizes.Max(s => s.Height);

            // Create a raster canvas (unbound) for merging
            JpegOptions canvasOptions = new JpegOptions();
            using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string file in files)
                {
                    using (JpegImage img = (JpegImage)Image.Load(file))
                    {
                        // Convert to grayscale
                        img.Grayscale();

                        // Copy pixels onto canvas
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));

                        offsetX += img.Width;
                    }
                }

                // Prepare PDF output
                string pdfPath = Path.Combine(outputDirectory, "merged.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    canvas.Save(pdfPath, pdfOptions);
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
 * 1. When you need to create a black‑and‑white PDF catalog from a set of color JPEG product photos.
 * 2. When you want to generate a printable report that combines several scanned JPEG pages as a single grayscale PDF.
 * 3. When you must reduce file size for archival by converting color JPEGs to grayscale before merging them into a PDF.
 * 4. When an application requires a side‑by‑side view of multiple images in a PDF without color information for OCR preprocessing.
 * 5. When you are building a document workflow that standardizes incoming JPEGs to grayscale and consolidates them into one PDF file.
 */
