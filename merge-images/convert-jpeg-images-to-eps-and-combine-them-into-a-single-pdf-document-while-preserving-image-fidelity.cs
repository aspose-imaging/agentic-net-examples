using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect JPEG file paths followed by the output PDF path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <jpeg1> <jpeg2> ... <output.pdf>");
            return;
        }

        string outputPdfPath = args[args.Length - 1];
        string[] jpegPaths = args.Take(args.Length - 1).ToArray();

        // Collect sizes of JPEG images and create intermediate EPS files
        List<Size> imageSizes = new List<Size>();
        foreach (string jpegPath in jpegPaths)
        {
            using (RasterImage jpegImage = (RasterImage)Image.Load(jpegPath))
            {
                imageSizes.Add(jpegImage.Size);

                // Save as EPS (intermediate step)
                string epsPath = Path.ChangeExtension(jpegPath, ".eps");
                jpegImage.Save(epsPath, new EpsOptions());
            }
        }

        // Determine canvas size for the PDF (vertical stacking)
        int canvasWidth = imageSizes.Max(s => s.Width);
        int canvasHeight = imageSizes.Sum(s => s.Height);

        // Temporary JPEG canvas to later be saved as PDF
        string tempJpegPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".jpg");
        Source tempSource = new FileCreateSource(tempJpegPath, false);
        JpegOptions jpegCanvasOptions = new JpegOptions { Source = tempSource, Quality = 100 };

        using (JpegImage canvas = (JpegImage)Image.Create(jpegCanvasOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (string jpegPath in jpegPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(jpegPath))
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the composed canvas as a PDF document
            PdfOptions pdfOptions = new PdfOptions();
            canvas.Save(outputPdfPath, pdfOptions);
        }

        // Clean up temporary JPEG file
        if (File.Exists(tempJpegPath))
        {
            File.Delete(tempJpegPath);
        }
    }
}