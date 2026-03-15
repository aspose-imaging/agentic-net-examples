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
        // Input JPG files to combine
        string[] jpgPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Collect sizes of all images
        List<Size> sizes = new List<Size>();
        foreach (var path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size for vertical stacking
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Sum(s => s.Height);

        // Create a temporary JPEG canvas (required for PDF creation)
        string tempJpegPath = Path.Combine(Path.GetTempPath(), "temp_canvas.jpg");
        Source tempSource = new FileCreateSource(tempJpegPath, true);
        JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            // Merge JPG images vertically onto the canvas
            int offsetY = 0;
            foreach (var path in jpgPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the combined canvas as PDF.
            // AVIF is not supported in PDF; fallback to JPEG compression.
            PdfOptions pdfOptions = new PdfOptions();
            string outputPdf = "output.pdf";
            canvas.Save(outputPdf, pdfOptions);
        }

        // Clean up temporary JPEG file
        if (File.Exists(tempJpegPath))
        {
            File.Delete(tempJpegPath);
        }
    }
}