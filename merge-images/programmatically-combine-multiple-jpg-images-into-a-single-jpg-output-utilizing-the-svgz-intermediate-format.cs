using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program.exe <input1.jpg> <input2.jpg> ... <output.jpg>");
            return;
        }

        // Last argument is the output JPEG path
        string outputPath = args[args.Length - 1];
        // All preceding arguments are input JPEG paths
        string[] inputPaths = args.Take(args.Length - 1).ToArray();

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (var path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size for horizontal stitching
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create an unbound raster canvas
        JpegOptions canvasOptions = new JpegOptions();
        using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save intermediate SVGZ using compression
            string intermediatePath = Path.ChangeExtension(outputPath, ".svgz");
            SvgOptions svgOptions = new SvgOptions { Compress = true };
            canvas.Save(intermediatePath, svgOptions);
        }

        // Load the SVGZ and rasterize to final JPEG
        using (Image svgImage = Image.Load(Path.ChangeExtension(outputPath, ".svgz")))
        {
            JpegOptions finalOptions = new JpegOptions { Quality = 90 };
            svgImage.Save(outputPath, finalOptions);
        }
    }
}