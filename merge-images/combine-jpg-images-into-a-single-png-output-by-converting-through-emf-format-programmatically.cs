using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files (modify paths as needed)
        string[] jpgPaths = new[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Collect sizes of all JPG images
        List<Size> sizes = new List<Size>();
        foreach (string path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(new Size(img.Width, img.Height));
            }
        }

        // Calculate canvas size for horizontal stitching
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (Size sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Create EMF recorder graphics with the calculated canvas size
        Rectangle frame = new Rectangle(0, 0, totalWidth, maxHeight);
        Size deviceSize = new Size(totalWidth, maxHeight);
        Size deviceSizeMm = new Size(totalWidth / 100, maxHeight / 100); // approximate mm size
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(frame, deviceSize, deviceSizeMm);

        // Draw each JPG onto the EMF canvas side by side
        int offsetX = 0;
        foreach (string path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                Rectangle srcRect = new Rectangle(0, 0, img.Width, img.Height);
                graphics.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
                offsetX += img.Width;
            }
        }

        // Finalize EMF recording
        using (EmfImage emfImage = graphics.EndRecording())
        {
            // Prepare PNG options with vector rasterization to convert EMF to PNG
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size
                }
            };

            // Output PNG path
            string outputPng = "combined.png";

            // Save the EMF image as PNG
            emfImage.Save(outputPng, pngOptions);
        }
    }
}