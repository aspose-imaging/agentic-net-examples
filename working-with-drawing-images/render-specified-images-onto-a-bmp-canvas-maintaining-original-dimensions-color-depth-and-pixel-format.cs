using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input image file paths (modify as needed)
        string[] imagePaths = new string[]
        {
            "image1.png",
            "image2.jpg",
            "image3.bmp"
        };

        // Output BMP file path
        string outputPath = "merged_output.bmp";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in imagePaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        // Create BMP options with a file source
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions
        {
            Source = source,
            BitsPerPixel = 24 // standard 24‑bpp BMP
        };

        // Create the canvas image (bound to the output file)
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            // Merge each image onto the canvas
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (no path needed)
            canvas.Save();
        }
    }
}