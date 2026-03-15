using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string[] jpgPaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
        string pngPath = "combined.png";
        string icoPath = "icon.ico";

        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Aspose.Imaging.Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        Source pngSource = new FileCreateSource(pngPath, false);
        PngOptions pngOptions = new PngOptions() { Source = pngSource };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in jpgPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            canvas.Save();
        }

        using (Image pngImg = Image.Load(pngPath))
        {
            IcoOptions icoOptions = new IcoOptions() { Source = new FileCreateSource(icoPath, false) };
            pngImg.Save(icoPath, icoOptions);
        }
    }
}