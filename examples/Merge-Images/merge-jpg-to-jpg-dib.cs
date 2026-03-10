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
        // Input JPEG files to merge
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output merged JPEG file
        string outputPath = "merged.jpg";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create JPEG options with bound output file
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions options = new JpegOptions()
        {
            Source = source,
            Quality = 100
        };

        // Create a JPEG canvas with the calculated size
        using (JpegImage canvas = (JpegImage)Image.Create(options, newWidth, newHeight))
        {
            int offsetX = 0;
            // Merge each image onto the canvas
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (no need to pass path again)
            canvas.Save();
        }
    }
}