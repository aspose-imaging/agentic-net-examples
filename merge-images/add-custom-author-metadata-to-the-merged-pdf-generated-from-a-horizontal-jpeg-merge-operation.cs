using System;
using System.IO;
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
            // Hardcoded input and output paths
            string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };
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

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight) canvasHeight = sz.Height;
            }

            // Create temporary JPEG canvas bound to a file
            string tempCanvasPath = "temp_canvas.jpg";
            Source tempSource = new FileCreateSource(tempCanvasPath, true);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
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

                // Set PDF metadata (author)
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                pdfOptions.PdfDocumentInfo.Author = "Custom Author";

                // Save the merged canvas as PDF
                canvas.Save(outputPath, pdfOptions);
            }

            // Cleanup temporary canvas file
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
 * 1. When a developer needs to combine multiple product photos into a single horizontally‑stitched PDF and embed the photographer’s name as the Author metadata for brand compliance.
 * 2. When an e‑learning platform wants to merge scanned lecture slides (JPEGs) into one PDF and automatically set the course instructor as the Author field for searchable course catalogs.
 * 3. When a legal firm creates a single PDF dossier from scanned evidence images and must add the attorney’s name as Author metadata to satisfy document‑tracking requirements.
 * 4. When a marketing automation tool assembles campaign banner images into a horizontal PDF brochure and includes the campaign manager’s name in the PDF metadata for audit trails.
 * 5. When a real‑estate application merges property interior photos into a PDF flyer and records the listing agent as the Author metadata to improve document indexing in property management systems.
 */