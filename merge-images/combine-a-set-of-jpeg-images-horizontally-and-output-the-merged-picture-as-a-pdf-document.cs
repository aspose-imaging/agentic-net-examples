using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG file paths
            string[] inputPaths = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            // Hardcoded output PDF path
            string outputPath = "merged.pdf";

            // Validate each input file exists
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
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (Size sz in sizes)
            {
                totalWidth += sz.Width;
                if (sz.Height > maxHeight) maxHeight = sz.Height;
            }

            // Create a temporary JPEG canvas bound to a temporary file
            string tempCanvasPath = "temp_canvas.jpg";
            Source tempSource = new FileCreateSource(tempCanvasPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                // Merge images horizontally onto the canvas
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

                // Save the merged canvas as a PDF document
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
            }

            // Clean up temporary canvas file
            if (File.Exists(tempCanvasPath))
            {
                File.Delete(tempCanvasPath);
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
 * 1. A retail developer can merge three product JPEG photos side‑by‑side into a single PDF page for a quick printable catalog preview.
 * 2. An accounting system can combine scanned JPEG images of multiple receipts into one horizontal PDF for streamlined expense reporting.
 * 3. A real‑estate portal can stitch together interior room photos into a single PDF sheet to showcase a property’s layout at a glance.
 * 4. A QA tool can place before‑and‑after screenshots horizontally and export them as a PDF for defect documentation.
 * 5. An e‑learning platform can align step‑by‑step instructional images in one row and generate a PDF handout for offline study.
 */