using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // args[0] = output BMP file path
        // args[1..] = input image file paths
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <output.bmp> <input1> [<input2> ...]");
            return;
        }

        string outputPath = args[0];
        string[] inputPaths = new string[args.Length - 1];
        Array.Copy(args, 1, inputPaths, 0, inputPaths.Length);

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal stitching)
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Create BMP canvas bound to output file
        Source src = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions() { Source = src };
        using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, canvasWidth, canvasHeight))
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

            // Save the bound BMP image
            canvas.Save();
        }
    }
}