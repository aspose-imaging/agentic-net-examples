using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output path
        string outputPath = "output/merged.jpg";

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

        // Collect image sizes
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Determine canvas dimensions with padding
        int padding = 20;
        int maxWidth = sizes.Max(s => s.Width);
        int totalHeight = sizes.Sum(s => s.Height);
        int canvasWidth = maxWidth + 2 * padding;
        int canvasHeight = totalHeight + (sizes.Count + 1) * padding;

        // Prepare JPEG options with bound source
        JpegOptions jpegOptions = new JpegOptions
        {
            Quality = 90,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create canvas and merge images vertically, centering each horizontally
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = padding;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    int offsetX = padding + (maxWidth - img.Width) / 2;
                    Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height + padding;
                }
            }

            // Save the bound canvas to the output file
            canvas.Save();
        }
    }
}