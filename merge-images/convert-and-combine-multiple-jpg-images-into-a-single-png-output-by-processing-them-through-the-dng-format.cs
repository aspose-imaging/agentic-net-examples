using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG image paths (modify as needed)
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Output PNG path
        string outputPath = "combined.png";

        // Collect sizes of all input images
        List<Size> sizeList = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizeList.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int newWidth = sizeList.Sum(s => s.Width);
        int newHeight = sizeList.Max(s => s.Height);

        // Create source and PNG options for the output canvas
        Source outputSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = outputSource };

        // Create a PNG canvas with the calculated dimensions
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            // Merge images horizontally onto the canvas
            int offsetX = 0;
            foreach (string imgPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(imgPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (output file is already bound via FileCreateSource)
            canvas.Save();
        }
    }
}