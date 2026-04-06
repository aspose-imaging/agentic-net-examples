using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input image paths
        string[] inputPaths = new[]
        {
            "image1.png",
            "image2.png",
            "image3.png"
        };

        // Hardcoded output path
        string outputPath = "output.apng";

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for side‑by‑side layout
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (Size sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Create source and APNG options
        Source source = new FileCreateSource(outputPath, false);
        ApngOptions options = new ApngOptions
        {
            Source = source,
            ColorType = PngColorType.TruecolorWithAlpha,
            DefaultFrameTime = 1000 // 1 second per frame (single frame animation)
        };

        // Create APNG canvas
        using (ApngImage canvas = (ApngImage)Image.Create(options, totalWidth, maxHeight))
        {
            int offsetX = 0;
            // Draw each image onto the canvas
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the APNG (canvas is already bound to the output source)
            canvas.Save();
        }
    }
}