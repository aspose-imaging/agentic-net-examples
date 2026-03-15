using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string[] inputPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
        string outputJpg = "combined.jpg";
        string tempTiff = "temp.tif";

        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (var path in inputPaths)
        {
            using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        int newWidth = 0;
        int newHeight = 0;
        foreach (var sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        FileCreateSource tiffSource = new FileCreateSource(tempTiff, false);
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            Source = tiffSource,
            Photometric = TiffPhotometrics.Rgb,
            BitsPerSample = new ushort[] { 8, 8, 8 }
        };

        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(tiffOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (var path in inputPaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            canvas.Save();
        }

        using (Aspose.Imaging.Image tiffImage = Aspose.Imaging.Image.Load(tempTiff))
        {
            JpegOptions jpegOptions = new JpegOptions() { Quality = 90 };
            tiffImage.Save(outputJpg, jpegOptions);
        }

        if (File.Exists(tempTiff))
        {
            File.Delete(tempTiff);
        }
    }
}