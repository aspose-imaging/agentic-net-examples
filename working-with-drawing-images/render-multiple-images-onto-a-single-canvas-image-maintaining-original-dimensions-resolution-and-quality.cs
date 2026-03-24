using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string[] inputPaths = new string[]
        {
            "input1.png",
            "input2.jpg",
            "input3.bmp"
        };
        string outputPath = "output.png";

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
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
            {
                sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create output file source and PNG options
        Source source = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = source };

        // Create canvas image
        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged image (bound to the output source)
            canvas.Save();
        }
    }
}