using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = @"C:\Images\input1.png";
        string inputPath2 = @"C:\Images\input2.png";
        string outputPath = @"C:\Images\output.png";

        // Validate input files
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of source images
        List<Size> sizes = new List<Size>();
        using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
        {
            sizes.Add(img1.Size);
        }
        using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
        {
            sizes.Add(img2.Size);
        }

        // Calculate canvas dimensions (horizontal stitch)
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Create output source and options with memory limit
        Source outputSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions
        {
            Source = outputSource,
            BufferSizeHint = 50 // limit internal buffers to 50 MB
        };

        // Create canvas bound to the output file
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            // Merge first image
            using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
            {
                Rectangle bounds = new Rectangle(offsetX, 0, img1.Width, img1.Height);
                canvas.SaveArgb32Pixels(bounds, img1.LoadArgb32Pixels(img1.Bounds));
                offsetX += img1.Width;
            }
            // Merge second image
            using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
            {
                Rectangle bounds = new Rectangle(offsetX, 0, img2.Width, img2.Height);
                canvas.SaveArgb32Pixels(bounds, img2.LoadArgb32Pixels(img2.Bounds));
                offsetX += img2.Width;
            }

            // Save the bound canvas (no path needed)
            canvas.Save();
        }
    }
}