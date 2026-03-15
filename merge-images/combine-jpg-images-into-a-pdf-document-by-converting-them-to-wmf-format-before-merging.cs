using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files (replace with actual paths)
        string[] jpgPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Output PDF file
        string outputPdf = "combined.pdf";

        // Collect sizes of all JPG images
        List<Size> sizes = new List<Size>();
        foreach (var path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal layout
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (var sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // DPI for WMF recording
        int dpi = 96;

        // Create WMF recorder graphics with calculated canvas size
        Rectangle canvasRect = new Rectangle(0, 0, totalWidth, maxHeight);
        WmfRecorderGraphics2D graphics = new WmfRecorderGraphics2D(canvasRect, dpi);

        // Draw each JPG onto the WMF canvas side by side
        int offsetX = 0;
        foreach (var path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                Rectangle srcRect = new Rectangle(0, 0, img.Width, img.Height);
                graphics.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
                offsetX += img.Width;
            }
        }

        // Finalize WMF image and save as PDF
        using (WmfImage wmfImage = graphics.EndRecording())
        {
            wmfImage.Save(outputPdf, new PdfOptions());
        }
    }
}