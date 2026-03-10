using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files to merge
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg"
            // Add more paths as needed
        };

        // Output JPEG2000 file
        string outputPath = "merged.jp2";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal merge)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create a bound JPEG2000 canvas
        Source source = new FileCreateSource(outputPath, false);
        Jpeg2000Options options = new Jpeg2000Options() { Source = source };
        using (Jpeg2000Image canvas = (Jpeg2000Image)Image.Create(options, canvasWidth, canvasHeight))
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

            // Save the bound image (no path needed)
            canvas.Save();
        }
    }
}