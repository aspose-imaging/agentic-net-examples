using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input file paths
        string jpgPath = "input.jpg";
        string pngPath = "input.png";
        string outputPath = "merged.png";

        // Collect sizes of input images
        List<Size> sizes = new List<Size>();
        using (RasterImage img1 = (RasterImage)Image.Load(jpgPath))
        {
            sizes.Add(img1.Size);
        }
        using (RasterImage img2 = (RasterImage)Image.Load(pngPath))
        {
            sizes.Add(img2.Size);
        }

        // Calculate canvas dimensions (horizontal merge)
        int newWidth = 0;
        int newHeight = 0;
        foreach (var size in sizes)
        {
            newWidth += size.Width;
            if (size.Height > newHeight)
                newHeight = size.Height;
        }

        // Create output source and PNG options
        Source source = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = source };

        // Create canvas and merge images
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in new[] { jpgPath, pngPath })
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged image (bound canvas)
            canvas.Save();
        }
    }
}