using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // args[0] - path to CDR canvas file (used for size reference)
        // args[1] - output PDF file path
        // args[2...] - JPEG image file paths to merge
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <program> <canvas.cdr> <output.pdf> <image1.jpg> [image2.jpg] ...");
            return;
        }

        string cdrPath = args[0];
        string outputPdfPath = args[1];
        List<string> jpegPaths = new List<string>();
        for (int i = 2; i < args.Length; i++)
        {
            jpegPaths.Add(args[i]);
        }

        // Load CDR canvas to obtain width and height
        using (CdrImage cdrCanvas = (CdrImage)Image.Load(cdrPath))
        {
            int canvasWidth = cdrCanvas.Width;
            int canvasHeight = cdrCanvas.Height;

            // Create an in‑memory raster canvas (PNG format) with the same dimensions
            PngOptions pngOptions = new PngOptions();
            using (Image rasterCanvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                // Clear canvas to white background
                Graphics graphics = new Graphics(rasterCanvas);
                graphics.Clear(Color.White);

                // Draw each JPEG onto the raster canvas
                foreach (string jpegPath in jpegPaths)
                {
                    using (Image jpegImage = Image.Load(jpegPath))
                    {
                        // Position each image at (0,0); modify as needed for offsets
                        graphics.DrawImage(jpegImage, new Rectangle(0, 0, jpegImage.Width, jpegImage.Height));
                    }
                }

                // Save the merged raster canvas as a PDF document
                PdfOptions pdfOptions = new PdfOptions();
                rasterCanvas.Save(outputPdfPath, pdfOptions);
            }
        }
    }
}