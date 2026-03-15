using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string[] imagePaths = { "image1.png", "image2.png", "image3.png" };

        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (var path in imagePaths)
        {
            using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        FileCreateSource canvasSource = new FileCreateSource("temp_canvas.png", false);
        PngOptions canvasOptions = new PngOptions { Source = canvasSource };
        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(canvasOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (var path in imagePaths)
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(path))
                {
                    var bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            FileCreateSource apngSource = new FileCreateSource("output.apng", false);
            ApngOptions apngOptions = new ApngOptions
            {
                Source = apngSource,
                DefaultFrameTime = 500,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (Aspose.Imaging.FileFormats.Apng.ApngImage apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)Aspose.Imaging.Image.Create(apngOptions, newWidth, newHeight))
            {
                apng.RemoveAllFrames();
                apng.AddFrame(canvas);
                apng.Save();
            }
        }
    }
}