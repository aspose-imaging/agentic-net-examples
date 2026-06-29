using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PDF path
            string inputPath = @"C:\Images\input.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PDF document
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Determine page count (PDF is a multipage vector image)
                var multipage = pdfImage as IMultipageImage;
                int pageCount = multipage?.PageCount ?? 1;

                // Loop through each page and export as PNG with alpha channel
                for (int pageIndex = 0; pageIndex < pageCount; pageIndex++)
                {
                    // Prepare PNG save options
                    var pngOptions = new PngOptions
                    {
                        // Ensure each page is saved individually
                        MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(pageIndex, pageIndex + 1))
                    };

                    // Configure vector rasterization to preserve transparency
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        // Use transparent background so alpha channel is retained
                        BackgroundColor = Aspose.Imaging.Color.Transparent,
                        // Preserve original size
                        PageSize = new SizeF(pdfImage.Width, pdfImage.Height),
                        // Optional: improve quality
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                    };

                    pngOptions.VectorRasterizationOptions = vectorOptions;

                    // Define output file path for the current page
                    string outputPath = Path.Combine(@"C:\Images\Output", $"page_{pageIndex + 1}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as PNG
                    pdfImage.Save(outputPath, pngOptions);
                }
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
 * 1. When a developer needs to convert multi‑page PDF brochures that contain vector illustrations into separate PNG files with preserved transparency for use on responsive web pages.
 * 2. When an e‑commerce platform must generate product‑label thumbnails from PDF templates, flattening any translucent elements so the PNG output retains an alpha channel for overlay on dynamic backgrounds.
 * 3. When a mobile app requires high‑resolution PNG assets extracted from a PDF design mockup, ensuring each page’s vector graphics are rasterized with a transparent background for seamless UI integration.
 * 4. When a reporting tool automates the creation of printable PNG charts from PDF dashboards, preserving vector quality and transparency to embed the images into PowerPoint slides.
 * 5. When a document‑management system needs to archive each page of a PDF contract as a PNG with an alpha channel, enabling quick preview thumbnails while maintaining the original vector‑based visual fidelity.
 */