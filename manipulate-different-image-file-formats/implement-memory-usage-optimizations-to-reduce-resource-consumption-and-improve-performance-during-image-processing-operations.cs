using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input image files to be merged (replace with actual paths)
        string[] inputPaths = { "image1.jpg", "image2.png", "image3.bmp" };
        string outputPath = "merged_output.jpg";

        // Collect sizes of all source images
        List<Size> sizes = new List<Size>();
        foreach (var path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                if (!img.IsCached) img.CacheData();
                sizes.Add(img.Size);
            }
        }

        // Compute canvas dimensions for a horizontal stitch
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Create a file source for the output image
        Source outSource = new FileCreateSource(outputPath, false);

        // Configure JPEG options with a memory limit (e.g., 50 MB)
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = outSource,
            Quality = 90,
            BufferSizeHint = 50 // memory limit in megabytes
        };

        // Create the output canvas bound to the file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            // Clear background to white
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            // Paste each source image onto the canvas
            int offsetX = 0;
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    if (!img.IsCached) img.CacheData();

                    Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                    // Transfer pixel data directly without loading the whole canvas into memory
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));

                    offsetX += img.Width;
                }
            }

            // Since the canvas is already bound to a file, just call Save()
            canvas.Save();
        }
    }
}