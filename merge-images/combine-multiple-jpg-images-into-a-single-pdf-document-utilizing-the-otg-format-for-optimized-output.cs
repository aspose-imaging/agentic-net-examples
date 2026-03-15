using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG image paths
        string[] imagePaths = new string[]
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

        // Calculate canvas size (vertical stacking)
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            if (sz.Width > canvasWidth) canvasWidth = sz.Width;
            canvasHeight += sz.Height;
        }

        // Temporary JPEG canvas file
        string tempJpegPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".jpg");
        Source tempSource = new FileCreateSource(tempJpegPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

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

            // Save canvas as PDF using OTG rasterization options
            string outputPdfPath = "CombinedOutput.pdf";
            PdfOptions pdfOptions = new PdfOptions();
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions();
            otgOptions.PageSize = canvas.Size;
            pdfOptions.VectorRasterizationOptions = otgOptions;

            canvas.Save(outputPdfPath, pdfOptions);
        }

        // Cleanup temporary JPEG file
        if (File.Exists(tempJpegPath))
        {
            File.Delete(tempJpegPath);
        }
    }
}