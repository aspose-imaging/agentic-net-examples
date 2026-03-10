using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input image paths (AVIF files). Since AVIF is unsupported, we will output JPEG.
        string[] imagePaths = new string[] { "image1.avif", "image2.avif", "image3.avif" };
        // Collect sizes of all input images.
        List<Size> sizes = new List<Size>();
        foreach (string path in imagePaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal layout.
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Output file (fallback to JPEG).
        string outputPath = "output.jpg";

        // Create file source and JPEG options.
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

        // Create bound JPEG canvas.
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            // Merge each image onto the canvas side by side.
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            // Save the bound image.
            canvas.Save();
        }
    }
}