using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input image paths
        string jpgPath = "input.jpg";
        string pngPath = "input.png";
        string outputPath = "output.avif";

        // Collect image sizes
        List<Size> sizes = new List<Size>();
        List<string> imagePaths = new List<string> { jpgPath, pngPath };
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
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Create output source and JPEG options (fallback since AVIF is unsupported)
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = source,
            Quality = 100
        };

        // Create canvas and merge images horizontally
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

            // AVIF format is not supported; throw exception as per guidelines
            throw new NotSupportedException("AVIF format is not supported by Aspose.Imaging.");
        }
    }
}