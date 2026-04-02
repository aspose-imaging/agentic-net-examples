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
        string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
        string outputPath = "merged_output.jpg";

        // Verify each input file exists
        foreach (var path in inputPaths)
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
        foreach (var path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        int border = 5;
        int totalWidth = sizes.Sum(s => s.Width) + 2 * border;
        int maxHeight = sizes.Max(s => s.Height) + 2 * border;

        // Create JPEG canvas with border space
        Source src = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = src, Quality = 90 };

        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
        {
            int offsetX = border;

            // Merge images horizontally inside the border
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, border, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (output path already bound via FileCreateSource)
            canvas.Save();
        }
    }
}