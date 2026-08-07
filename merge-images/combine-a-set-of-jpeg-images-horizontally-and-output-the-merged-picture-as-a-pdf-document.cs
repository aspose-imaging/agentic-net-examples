using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
            // Input JPEG files (hardcoded relative paths)
            string[] inputPaths = new string[]
            {
                "Input/image1.jpg",
                "Input/image2.jpg",
                "Input/image3.jpg"
            };

            // Output PDF file (hardcoded relative path)
            string outputPath = "Output/merged.pdf";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

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
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Temporary JPEG file to serve as intermediate canvas source
            string tempJpegPath = Path.Combine(Path.GetTempPath(), "temp_merge.jpg");
            Source tempSource = new FileCreateSource(tempJpegPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = tempSource,
                Quality = 100
            };

            // Create JPEG canvas
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

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the merged image as PDF
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When a developer needs to generate a single PDF report that shows multiple product photos side‑by‑side, they can use this code to merge JPEG images horizontally and save the result as a PDF.
 * 2. When an e‑commerce platform wants to create a printable catalog page that combines several item images into one PDF sheet, this C# snippet merges the JPEGs and outputs a PDF document.
 * 3. When a medical imaging system must bundle a series of scanned X‑ray JPEGs into a single PDF for easy sharing with clinicians, the code provides a quick horizontal merge and PDF export.
 * 4. When a real‑estate application wants to combine interior and exterior JPEG photos of a property into a single PDF flyer, the example shows how to stitch the images horizontally and save them as a PDF.
 * 5. When an automated document workflow needs to concatenate marketing banner JPEGs into one PDF brochure page, this code demonstrates the necessary image loading, canvas creation, and PDF output in .NET.
 */