using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // args[0] = path to CDR canvas file (used only for size reference)
        // args[1] = output PNG file path
        // args[2...] = input JPG image file paths
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <program> <canvas.cdr> <output.png> <input1.jpg> [<input2.jpg> ...]");
            return;
        }

        string cdrPath = args[0];
        string outputPath = args[1];
        string[] inputPaths = new string[args.Length - 2];
        Array.Copy(args, 2, inputPaths, 0, inputPaths.Length);

        // Load CDR canvas to obtain target dimensions
        int canvasWidth;
        int canvasHeight;
        using (CdrImage cdrCanvas = (CdrImage)Image.Load(cdrPath))
        {
            canvasWidth = cdrCanvas.Width;
            canvasHeight = cdrCanvas.Height;
        }

        // Load all input JPG images and collect them
        List<RasterImage> inputImages = new List<RasterImage>();
        foreach (string path in inputPaths)
        {
            RasterImage img = (RasterImage)Image.Load(path);
            inputImages.Add(img);
        }

        // Calculate total width (horizontal stitching) and max height
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (RasterImage img in inputImages)
        {
            totalWidth += img.Width;
            if (img.Height > maxHeight)
                maxHeight = img.Height;
        }

        // If calculated dimensions exceed canvas, adjust canvas size
        int finalWidth = Math.Max(canvasWidth, totalWidth);
        int finalHeight = Math.Max(canvasHeight, maxHeight);

        // Prepare PNG options with bound file source
        Source pngSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions { Source = pngSource };

        // Create raster canvas bound to the output PNG file
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, finalWidth, finalHeight))
        {
            // Merge input images horizontally onto the canvas
            int offsetX = 0;
            foreach (RasterImage img in inputImages)
            {
                Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                offsetX += img.Width;
            }

            // Save the bound canvas (no path needed because source is already set)
            canvas.Save();
        }

        // Dispose all loaded input images
        foreach (RasterImage img in inputImages)
        {
            img.Dispose();
        }
    }
}