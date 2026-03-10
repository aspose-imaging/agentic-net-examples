using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG image paths
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output TGA path
        string outputPath = "merged.tga";

        // Collect sizes of all input images
        List<Aspose.Imaging.Size> sizeList = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizeList.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizeList)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        // Create output source and TGA options
        Source outputSource = new FileCreateSource(outputPath, false);
        TgaOptions tgaOptions = new TgaOptions() { Source = outputSource };

        // Create canvas bound to the output file
        using (RasterImage canvas = (RasterImage)Image.Create(tgaOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (no path needed)
            canvas.Save();
        }
    }
}