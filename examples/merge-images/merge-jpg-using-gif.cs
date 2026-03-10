using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect input JPG paths followed by output GIF path
        if (args.Length < 2)
            return;

        string outputPath = args[args.Length - 1];
        string[] inputPaths = new string[args.Length - 1];
        Array.Copy(args, inputPaths, args.Length - 1);

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
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight)
                newHeight = sz.Height;
        }

        // Create GIF canvas bound to output file
        Source source = new FileCreateSource(outputPath, false);
        GifOptions gifOptions = new GifOptions() { Source = source };
        using (RasterImage canvas = (RasterImage)Image.Create(gifOptions, newWidth, newHeight))
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
            // Save the bound GIF image
            canvas.Save();
        }
    }
}