using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string[] inputPaths = new string[] { "input1.avif", "input2.avif", "input3.avif" };
        string outputPath = "output.jpg";

        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        FileCreateSource source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = source,
            Quality = 100
        };

        using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
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
    }
}