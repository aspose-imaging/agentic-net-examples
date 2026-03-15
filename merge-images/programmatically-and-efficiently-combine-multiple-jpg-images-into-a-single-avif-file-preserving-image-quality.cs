using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect at least two input JPG paths and one output path
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <input1.jpg> <input2.jpg> ... <output.avif>");
            return;
        }

        // Last argument is the output file path
        string outputPath = args[args.Length - 1];
        string outputExtension = Path.GetExtension(outputPath).ToLowerInvariant();

        // AVIF format is not supported by Aspose.Imaging save options; throw exception as per guidelines
        if (outputExtension == ".avif")
        {
            throw new NotSupportedException("AVIF format is not supported by Aspose.Imaging in this context.");
        }

        // Collect input image paths
        var inputPaths = new List<string>();
        for (int i = 0; i < args.Length - 1; i++)
        {
            inputPaths.Add(args[i]);
        }

        // Load images and collect their sizes
        var sizes = new List<Size>();
        foreach (var path in inputPaths)
        {
            using (JpegImage img = (JpegImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size for horizontal stitching
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (var sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Create a temporary PNG canvas to hold the merged image
        Source canvasSource = new FileCreateSource(Path.ChangeExtension(outputPath, ".png"), false);
        PngOptions pngOptions = new PngOptions { Source = canvasSource };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            foreach (var path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged image in the requested format (fallback to PNG if not AVIF)
            canvas.Save(outputPath);
        }
    }
}