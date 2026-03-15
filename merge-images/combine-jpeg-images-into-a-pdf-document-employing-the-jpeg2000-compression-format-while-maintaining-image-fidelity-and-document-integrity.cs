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
        // Input JPEG image paths
        List<string> imagePaths = new List<string>
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Collect sizes of all images
        List<Size> sizes = new List<Size>();
        foreach (string path in imagePaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for vertical stacking
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Sum(s => s.Height);

        // Temporary JPEG canvas file (intermediate bound image)
        string tempCanvasPath = Path.Combine(Path.GetTempPath(), "tempCanvas.jpg");
        Source tempSource = new FileCreateSource(tempCanvasPath, true);
        JpegOptions jpegOptions = new JpegOptions { Source = tempSource, Quality = 100 };

        // Create JPEG canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the canvas as a PDF with JPEG2000 compression (using default PDF options)
            PdfOptions pdfOptions = new PdfOptions();
            canvas.Save("output.pdf", pdfOptions);
        }

        // Cleanup temporary canvas file
        if (File.Exists(tempCanvasPath))
        {
            File.Delete(tempCanvasPath);
        }
    }
}