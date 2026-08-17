// HOW-TO: Add Author Metadata to Horizontally Merged JPEG PDF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input JPEG files
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Validate each input file
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Output PDF file
            string outputPdfPath = "merged.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

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
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight) canvasHeight = sz.Height;
            }

            // Temporary JPEG file that will hold the merged image
            string tempJpegPath = "temp_merged.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));

            // Create source for JPEG canvas
            Source jpegSource = new FileCreateSource(tempJpegPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = jpegSource, Quality = 100 };

            // Create JPEG canvas bound to the source
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

                // Save the bound JPEG canvas
                canvas.Save();
            }

            // Load the merged JPEG and save as PDF with custom author metadata
            using (Image pdfSource = Image.Load(tempJpegPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo() { Author = "Custom Author" };
                pdfSource.Save(outputPdfPath, pdfOptions);
            }

            // Optionally delete the temporary JPEG file
            if (File.Exists(tempJpegPath))
            {
                File.Delete(tempJpegPath);
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
 * 1. When a developer needs to combine several product photos side‑by‑side into a single PDF report and embed the creator’s name for compliance.
 * 2. When an application must generate a printable catalog by stitching landscape images horizontally and tag the PDF with author information for digital rights management.
 * 3. When a workflow requires converting a series of scanned receipts (JPEG) into one PDF document while preserving the author metadata for audit trails.
 * 4. When a web service creates a combined brochure from multiple JPEG banners and needs to set the PDF author field so the document can be searched by author in document management systems.
 * 5. When an automated script assembles marketing banners into a single PDF and adds custom author metadata to satisfy corporate branding guidelines.
 */
