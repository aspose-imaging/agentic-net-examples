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

            // Hardcoded output PDF file
            string outputPath = "merged.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of all input images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
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
            foreach (var sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Temporary bound JPEG file for canvas creation
            string tempCanvasPath = "temp_canvas.jpg";
            Source tempSource = new FileCreateSource(tempCanvasPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

            // PDF options with custom author metadata
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
            pdfOptions.PdfDocumentInfo.Author = "Custom Author";

            // Create bound JPEG canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
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

                // Save the merged canvas as PDF with metadata
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
 * 1. When a developer needs to combine multiple product photos stored as JPEGs into a single horizontally‑aligned PDF catalog and embed the photographer’s name as author metadata for brand attribution.
 * 2. When an application must create a printable marketing brochure by stitching together promotional images side‑by‑side and record the campaign manager’s name in the PDF metadata for compliance tracking.
 * 3. When a legal firm wants to merge scanned evidence JPEGs into one PDF file, preserving the investigator’s name as the author metadata to maintain chain‑of‑custody documentation.
 * 4. When a real‑estate portal generates a property showcase PDF by horizontally merging room‑by‑room JPEG images and automatically adds the listing agent’s name as author metadata for contact reference.
 * 5. When an educational platform assembles lecture slide screenshots into a single PDF worksheet and includes the instructor’s name as author metadata to credit the content creator.
 */