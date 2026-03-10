using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input image paths
        string jpgPath = "input.jpg";
        string pngPath = "input.png";

        // Output WebP path
        string outputPath = "merged_output.webp";

        // Collect sizes of input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();

        using (RasterImage jpgImage = (RasterImage)Image.Load(jpgPath))
        {
            sizes.Add(jpgImage.Size);
        }

        using (RasterImage pngImage = (RasterImage)Image.Load(pngPath))
        {
            sizes.Add(pngImage.Size);
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (var sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Prepare WebP options with bound source
        Source source = new FileCreateSource(outputPath, false);
        WebPOptions webpOptions = new WebPOptions()
        {
            Source = source,
            Lossless = false,
            Quality = 80f
        };

        // Create WebP canvas
        using (RasterImage canvas = (RasterImage)Image.Create(webpOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            string[] imagePaths = new string[] { jpgPath, pngPath };
            foreach (string imgPath in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(imgPath))
                {
                    // Define destination bounds on the canvas
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    // Copy pixel data
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound WebP image
            canvas.Save();
        }
    }
}