using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output paths
        string jpgPath = args.Length > 0 ? args[0] : "input.jpg";
        string pngPath = args.Length > 1 ? args[1] : "input.png";
        string outputPath = args.Length > 2 ? args[2] : "output.j2k";

        // Collect sizes of input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        string[] inputPaths = new string[] { jpgPath, pngPath };
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (Aspose.Imaging.Size sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create output source and JPEG2000 options
        Source source = new FileCreateSource(outputPath, false);
        Jpeg2000Options options = new Jpeg2000Options() { Source = source };

        // Create canvas bound to the output file
        using (RasterImage canvas = (RasterImage)Image.Create(options, newWidth, newHeight))
        {
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
            // Save the merged image (output is already bound)
            canvas.Save();
        }
    }
}