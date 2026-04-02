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
        // Hardcoded input and output paths
        string[] inputPaths = new[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };
        string outputPath = "output/merged.jpg";

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

        const int uniformWidth = 200; // Desired width for each image after resizing
        var sizes = new List<Size>();

        // First pass: resize each image and collect its size
        foreach (string path in inputPaths)
        {
            using (JpegImage img = new JpegImage(path))
            {
                int newHeight = (int)((double)img.Height * uniformWidth / img.Width);
                img.Resize(uniformWidth, newHeight);
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create JPEG canvas with bound source
        Source src = new FileCreateSource(outputPath, false);
        JpegOptions jpegOpts = new JpegOptions() { Source = src, Quality = 90 };
        using (JpegImage canvas = new JpegImage(jpegOpts, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            // Second pass: load, resize, and copy each image onto the canvas
            foreach (string path in inputPaths)
            {
                using (JpegImage img = new JpegImage(path))
                {
                    int newHeight = (int)((double)img.Height * uniformWidth / img.Width);
                    img.Resize(uniformWidth, newHeight);
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            // Save the merged image (bound image, so just call Save())
            canvas.Save();
        }
    }
}