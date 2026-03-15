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
        // args[0] = output PDF path, remaining args = input JPG paths
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program output.pdf input1.jpg [input2.jpg ...]");
            return;
        }

        string outputPdfPath = args[0];
        string[] jpgPaths = args.Skip(1).ToArray();

        // Collect sizes of JPG images
        var sizes = new List<Size>();
        foreach (var jpgPath in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(jpgPath))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size for vertical stacking
        int canvasWidth = sizes.Max(s => s.Width);
        int canvasHeight = sizes.Sum(s => s.Height);

        // Create PDF canvas using a bound JpegImage
        Source pdfSource = new FileCreateSource(outputPdfPath, false);
        var jpegOptions = new JpegOptions { Source = pdfSource, Quality = 100 };
        using (JpegImage pdfCanvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (var jpgPath in jpgPaths)
            {
                using (RasterImage pageImage = (RasterImage)Image.Load(jpgPath))
                {
                    var bounds = new Rectangle(0, offsetY, pageImage.Width, pageImage.Height);
                    pdfCanvas.SaveArgb32Pixels(bounds, pageImage.LoadArgb32Pixels(pageImage.Bounds));
                    offsetY += pageImage.Height;
                }
            }

            // Save the combined image as PDF
            var pdfOptions = new PdfOptions();
            pdfCanvas.Save(outputPdfPath, pdfOptions);
        }
    }
}