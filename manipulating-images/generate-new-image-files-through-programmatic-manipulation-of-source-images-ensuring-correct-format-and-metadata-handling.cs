using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string[] inputPaths = new string[]
        {
            "image1.tif",
            "image2.tif",
            "image3.tif"
        };

        string outputPath = "merged_big.tif";

        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        Source fileSource = new FileCreateSource(outputPath, false);
        BigTiffOptions tiffOptions = new BigTiffOptions(TiffExpectedFormat.Default)
        {
            Source = fileSource
        };

        using (TiffImage canvas = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    if (!img.IsCached) img.CacheData();

                    Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));

                    offsetX += img.Width;
                }
            }

            canvas.Save();
        }
    }
}