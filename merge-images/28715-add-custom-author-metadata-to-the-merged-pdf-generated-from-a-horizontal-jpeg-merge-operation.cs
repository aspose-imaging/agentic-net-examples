// HOW-TO: Merge Multiple JPEGs Horizontally Into PDF and Set Author Metadata In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input image paths
            string[] inputPaths = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            // Validate each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Output PDF path
            string outputPdfPath = "merged.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Temporary JPEG file used as bound source for the canvas
            string tempJpegPath = "temp.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));
            Source tempSource = new FileCreateSource(tempJpegPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = tempSource,
                Quality = 100
            };

            // Create canvas bound to temporary JPEG source
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
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

                // Prepare PDF options with custom author metadata
                PdfOptions pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Custom Author"
                    }
                };

                // Save the merged canvas as PDF
                canvas.Save(outputPdfPath, pdfOptions);
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
 * 1. When you need to combine several product photos into a single PDF brochure while preserving the original JPEG quality.
 * 2. When you must generate a PDF report that displays scanned receipts side by side and include the creator’s name in the document metadata.
 * 3. When an e‑commerce platform wants to create a printable catalog page by stitching horizontal images and embedding author information for copyright tracking.
 * 4. When a legal firm needs to merge signed JPEG agreements into one PDF file and record the attorney’s name as the document author.
 * 5. When an automated workflow creates a PDF portfolio of marketing banners and requires custom author metadata for document management systems.
 */
