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
            // Hardcoded input JPEG files and output PDF path
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "merged.pdf";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

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
            int newWidth = 0;
            int newHeight = 0;
            foreach (Size sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Create an unbound JPEG canvas
            JpegOptions canvasOptions = new JpegOptions();
            using (JpegImage canvas = (JpegImage)Image.Create(canvasOptions, newWidth, newHeight))
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

                // Configure PDF options (default settings)
                PdfOptions pdfOptions = new PdfOptions();

                // Save the merged image as PDF
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
 * 1. When a developer needs to combine multiple product photos stored as JPEG files into a single A4‑sized PDF catalog page for printing or distribution.
 * 2. When an application must generate a printable PDF report that stitches together scanned receipts (JPEG) side‑by‑side on an A4 sheet for accounting audits.
 * 3. When a web service creates a PDF portfolio of horizontally aligned JPEG artwork thumbnails, ensuring the output matches standard A4 dimensions for client review.
 * 4. When an automated workflow merges daily camera snapshots (JPEG) into an A4 PDF timeline for archival or compliance purposes.
 * 5. When a desktop utility converts a series of JPEG screenshots into a single A4 PDF slide deck, using Aspose.Imaging’s PdfOptions to control page size.
 */