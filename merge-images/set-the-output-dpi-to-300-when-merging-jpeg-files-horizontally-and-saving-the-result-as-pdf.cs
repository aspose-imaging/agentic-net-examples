using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG files
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            // Hardcoded output PDF file
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
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

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

            // Create canvas with 300 DPI resolution
            JpegOptions canvasOptions = new JpegOptions
            {
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, newWidth, newHeight))
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

                // Save merged canvas as PDF with 300 DPI
                PdfOptions pdfOptions = new PdfOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };
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
 * 1. When a publishing workflow needs to combine multiple high‑resolution product photos into a single printable PDF brochure, a developer can use this code to merge the JPEGs side‑by‑side and enforce a 300 DPI output for crisp print quality.
 * 2. When an e‑learning platform generates printable study guides from scanned lecture slides stored as JPEGs, the code can stitch the images horizontally into a PDF with 300 DPI to meet standard academic printing requirements.
 * 3. When a real‑estate agency creates property flyers by aligning room‑by‑room JPEG snapshots in a single landscape PDF, the developer can apply this snippet to ensure the final document retains 300 DPI for high‑quality marketing prints.
 * 4. When a legal document management system needs to archive multiple scanned signatures saved as JPEGs into a single PDF file, the code guarantees a 300 DPI resolution so the signatures remain legible in printed records.
 * 5. When a manufacturing quality‑control system compiles side‑by‑side JPEG images of component inspections into a PDF report, the developer can use this example to produce a 300 DPI PDF that satisfies ISO printing standards.
 */