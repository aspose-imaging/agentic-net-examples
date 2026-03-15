using System;
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
        // Expect at least one input image and an output path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input1> <input2> ... <output.jpg>");
            return;
        }

        // Last argument is the output JPEG file path
        string outputPath = args[args.Length - 1];
        string[] inputPaths = args.Take(args.Length - 1).ToArray();

        // Collect sizes of all input images
        List<Size> sizeList = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizeList.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for vertical stacking
        int newWidth = sizeList.Max(s => s.Width);
        int newHeight = sizeList.Sum(s => s.Height);

        // Create source and JPEG options for the output canvas
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };

        // Create a JPEG canvas with the calculated size
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetY = 0;
            // Merge each image vertically onto the canvas
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }

            // Save the bound image (source already set in options)
            canvas.Save();
        }
    }
}