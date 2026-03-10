using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files to merge
        string[] inputFiles = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output EMF file
        string outputFile = "merged.emf";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(new Size(img.Width, img.Height));
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Convert canvas size to millimeters (approx. 1 pixel = 0.01 mm)
        int canvasWidthMm = (int)(canvasWidth / 100f);
        int canvasHeightMm = (int)(canvasHeight / 100f);

        // Create EMF graphics recorder (do NOT wrap in using)
        Rectangle frame = new Rectangle(0, 0, canvasWidth, canvasHeight);
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(canvasWidth, canvasHeight),
            new Size(canvasWidthMm, canvasHeightMm));

        // Draw each JPG onto the EMF canvas side by side
        int offsetX = 0;
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                Rectangle srcRect = new Rectangle(0, 0, img.Width, img.Height);
                Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                graphics.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
                offsetX += img.Width;
            }
        }

        // Finalize EMF image and save
        using (EmfImage emfImage = graphics.EndRecording())
        {
            emfImage.Save(outputFile);
        }
    }
}