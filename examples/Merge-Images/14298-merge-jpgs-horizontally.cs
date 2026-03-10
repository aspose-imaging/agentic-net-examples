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
        // Input JPEG image file paths
        string[] imagePaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output merged JPEG file path
        string outputPath = "merged.jpg";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in imagePaths)
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

        // Create JPEG options with output source and quality
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = outputSource,
            Quality = 90
        };

        // Create JPEG canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (no need to pass path again)
            canvas.Save();
        }
    }
}