using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files
        string[] jpgFiles = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in jpgFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        // Prepare PNG output
        string pngPath = Path.Combine(Directory.GetCurrentDirectory(), "combined.png");
        Source pngSource = new FileCreateSource(pngPath, false);
        PngOptions pngOptions = new PngOptions() { Source = pngSource };

        // Create PNG canvas and merge images
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in jpgFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            // Save the bound PNG image
            canvas.Save();
        }

        // Convert the PNG to compressed EMZ (EMF with compression)
        string emzPath = Path.Combine(Directory.GetCurrentDirectory(), "combined.emz");
        using (Image pngImage = Image.Load(pngPath))
        {
            Source emzSource = new FileCreateSource(emzPath, false);
            EmfOptions emfOptions = new EmfOptions()
            {
                Source = emzSource,
                Compress = true
            };
            pngImage.Save(emzPath, emfOptions);
        }
    }
}