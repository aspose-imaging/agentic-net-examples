using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Webp;

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

        // Output PNG file path
        string outputPngPath = "combined_output.png";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal stitching)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create a blank PNG canvas to hold the combined image
        using (PngImage canvas = new PngImage(canvasWidth, canvasHeight, PngColorType.TruecolorWithAlpha))
        {
            int offsetX = 0;
            foreach (string path in jpgPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Define the region on the canvas where the current image will be placed
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    // Copy pixel data from the JPG to the canvas
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Convert the combined canvas to a WebP image
            using (WebPImage webp = new WebPImage(canvas))
            {
                // Save the WebP image as PNG (through the conversion process)
                webp.Save(outputPngPath, new PngOptions());
            }
        }
    }
}