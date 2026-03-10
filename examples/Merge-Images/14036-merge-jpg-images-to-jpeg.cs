using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG file paths
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output JPEG file path
        string outputPath = "merged.jpg";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        // Create output source and JPEG options
        Source src = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = src,
            Quality = 100
        };

        // Create a bound JPEG canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            // Merge images horizontally onto the canvas
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (output file is already bound to the source)
            canvas.Save();
        }
    }
}