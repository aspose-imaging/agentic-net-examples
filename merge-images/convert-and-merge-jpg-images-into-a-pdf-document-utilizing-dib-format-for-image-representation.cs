using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths of the source JPG images
        string[] jpgPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Determine the size of the horizontal canvas
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (string path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                totalWidth += img.Width;
                if (img.Height > maxHeight)
                    maxHeight = img.Height;
            }
        }

        // Create an in‑memory BMP canvas (DIB representation)
        BmpOptions bmpOptions = new BmpOptions();
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, totalWidth, maxHeight))
        {
            // Merge the JPG images side by side onto the canvas
            int offsetX = 0;
            foreach (string path in jpgPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged canvas as a PDF document
            PdfOptions pdfOptions = new PdfOptions();
            canvas.Save("merged.pdf", pdfOptions);
        }
    }
}