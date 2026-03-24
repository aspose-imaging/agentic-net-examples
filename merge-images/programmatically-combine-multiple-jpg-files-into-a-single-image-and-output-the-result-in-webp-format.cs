using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output WebP file
        string outputPath = "output.webp";

        // Validate each input file exists
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

        // Calculate canvas dimensions (horizontal stitching)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Prepare WebP options with bound source
        Source source = new FileCreateSource(outputPath, false);
        WebPOptions options = new WebPOptions()
        {
            Source = source,
            Lossless = false,
            Quality = 80
        };

        // Create canvas and merge images side by side
        using (RasterImage canvas = (RasterImage)Image.Create(options, canvasWidth, canvasHeight))
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

            // Save the bound canvas (output path already set in options)
            canvas.Save();
        }
    }
}