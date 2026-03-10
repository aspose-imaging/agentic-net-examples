using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files to merge
        string[] inputFiles = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Output merged JPG file
        string outputFile = "merged.jpg";

        // Collect sizes of all input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (var path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create an in‑memory TIFF canvas
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        using (RasterImage canvas = (RasterImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
        {
            // Merge each JPG onto the canvas
            int offsetX = 0;
            foreach (var path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged result as JPG
            JpegOptions jpegOptions = new JpegOptions { Quality = 90 };
            canvas.Save(outputFile, jpegOptions);
        }
    }
}