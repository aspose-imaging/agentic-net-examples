// HOW-TO: Crop JPEG Images to Central Square and Merge Vertically into PDF in C# (Aspose.Imaging for .NET)
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
            // -------------------- batch initialization (atomic block) --------------------
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");
            // ---------------------------------------------------------------------------

            // Filter JPEG files (case‑insensitive)
            var jpegFiles = files.Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)).ToList();

            if (jpegFiles.Count == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // First pass: determine square side for each image
            List<int> sides = new List<int>();
            foreach (string file in jpegFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (JpegImage img = (JpegImage)Image.Load(file))
                {
                    int side = Math.Min(img.Width, img.Height);
                    sides.Add(side);
                }
            }

            int maxWidth = sides.Max();
            int totalHeight = sides.Sum();

            // Prepare output PDF path
            string outputPdfPath = Path.Combine(outputDirectory, "merged.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Create an unbound canvas (raster image) for merging
            using (JpegOptions canvasOptions = new JpegOptions())
            {
                using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, maxWidth, totalHeight))
                {
                    int offsetY = 0;
                    for (int i = 0; i < jpegFiles.Count; i++)
                    {
                        string file = jpegFiles[i];
                        int side = sides[i];

                        using (JpegImage img = (JpegImage)Image.Load(file))
                        {
                            // Center crop to a square region
                            int cropX = (img.Width - side) / 2;
                            int cropY = (img.Height - side) / 2;
                            img.Crop(new Rectangle(cropX, cropY, side, side));

                            // Center horizontally on the canvas
                            int offsetX = (maxWidth - side) / 2;

                            // Copy pixels onto the canvas
                            canvas.SaveArgb32Pixels(
                                new Rectangle(offsetX, offsetY, side, side),
                                img.LoadArgb32Pixels(img.Bounds));

                            offsetY += side;
                        }
                    }

                    // Save the merged image as PDF
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        canvas.Save(outputPdfPath, pdfOptions);
                    }
                }
            }

            Console.WriteLine($"Merged PDF created at: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a printable PDF catalog where each product photo is a centered square thumbnail stacked vertically.
 * 2. When you must automatically trim a batch of user‑uploaded JPEGs to a uniform square before combining them into a single PDF report.
 * 3. When creating a vertical photo storyboard for a presentation and require the source images to be cropped to the same central area.
 * 4. When a web service receives varied‑size JPEGs and you need to standardize them and bundle them into one PDF document for archival.
 * 5. When building a C# utility that prepares passport‑style square images from original photos and merges them into a PDF for batch printing.
 */
