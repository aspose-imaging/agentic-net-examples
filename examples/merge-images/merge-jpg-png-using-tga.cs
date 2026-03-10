using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input file paths
        string jpgPath = "input.jpg";
        string pngPath = "input.png";

        // Output TGA file path
        string outputPath = "merged.tga";

        // Collect sizes of input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        using (RasterImage jpg = (RasterImage)Image.Load(jpgPath))
        {
            sizes.Add(jpg.Size);
        }
        using (RasterImage png = (RasterImage)Image.Load(pngPath))
        {
            sizes.Add(png.Size);
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (var sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create source and options for TGA output
        Source source = new FileCreateSource(outputPath, false);
        TgaOptions tgaOptions = new TgaOptions() { Source = source };

        // Create canvas image
        using (RasterImage canvas = (RasterImage)Image.Create(tgaOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            string[] imagePaths = new string[] { jpgPath, pngPath };
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Define destination rectangle on the canvas
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    // Copy pixel data
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (output path already bound in source)
            canvas.Save();
        }
    }
}