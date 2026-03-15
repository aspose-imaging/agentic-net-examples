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
        // Expect input JPG file paths as arguments, last argument is output PNG path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input1.jpg> <input2.jpg> ... <output.png>");
            return;
        }

        // Separate input and output paths
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

        // Calculate canvas dimensions (horizontal concatenation)
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        // Prepare PNG creation options with bound output file
        Source src = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = src };

        // Create canvas and merge images side by side
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Load pixel data from source image
                    int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                    // Define destination rectangle on the canvas
                    Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                    // Paste pixels onto canvas
                    canvas.SaveArgb32Pixels(destRect, pixels);
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (no need to specify path again)
            canvas.Save();
        }

        Console.WriteLine($"Combined image saved to {outputPath}");
    }
}