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
            // Input JPEG files (hardcoded)
            string[] inputPaths = { "Input/image1.jpg", "Input/image2.jpg", "Input/image3.jpg" };

            // Validate input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Collect sizes
            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int newWidth = 0;
            int newHeight = 0;
            foreach (var sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Temporary JPEG canvas path
            string tempJpegPath = "temp_canvas.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath) ?? ".");

            // Create JPEG canvas
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(tempJpegPath, false),
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                // Save the temporary JPEG canvas
                canvas.Save();
            }

            // Prepare PDF options with A4 page size (595x842 points)
            PdfOptions pdfOptions = new PdfOptions
            {
                PageSize = new Size(595, 842)
            };

            // Output PDF path
            string outputPdfPath = "Output/merged.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath) ?? ".");

            // Load the temporary JPEG and save as PDF
            using (Image pdfSource = Image.Load(tempJpegPath))
            {
                pdfSource.Save(outputPdfPath, pdfOptions);
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
 * 1. When a developer needs to combine multiple product photos stored as JPEGs into a single A4‑sized PDF brochure for printing, they can use this code to horizontally merge the images and set PdfOptions to A4 page size.
 * 2. When an e‑commerce platform wants to generate printable order summaries that stitch together customer‑uploaded JPEG receipts side‑by‑side on an A4 PDF page, this snippet shows how to configure PdfOptions accordingly.
 * 3. When a real‑estate agency requires a PDF flyer that places several property JPEG images next to each other on a standard A4 sheet for distribution, the code demonstrates the necessary image canvas creation and A4 PDF configuration.
 * 4. When a medical imaging system must export a series of diagnostic JPEG scans as a single A4 PDF report with the images arranged horizontally, the example illustrates using Aspose.Imaging to merge the images and set the PDF page size.
 * 5. When a marketing team needs to automate the creation of A4‑format PDF catalogs from a collection of horizontally aligned JPEG banners using C# and Aspose.Imaging, this code provides the exact steps to configure PdfOptions for A4 output.
 */