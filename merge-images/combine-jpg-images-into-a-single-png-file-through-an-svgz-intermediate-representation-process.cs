using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputFiles = {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Validate input files
        foreach (string inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Output intermediate SVGZ and final PNG paths
        string svgzPath = "combined.svgz";
        string pngPath = "combined.png";

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(svgzPath));
        Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

        // Collect sizes of input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string inputPath in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(inputPath))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal stitching)
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (var sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Create an empty canvas (unbound)
        PngOptions canvasOptions = new PngOptions();
        using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, totalWidth, maxHeight))
        {
            // Merge images side by side
            int offsetX = 0;
            foreach (string inputPath in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                    canvas.SaveArgb32Pixels(bounds, pixels);
                    offsetX += img.Width;
                }
            }

            // Save intermediate SVGZ
            SvgOptions svgOptions = new SvgOptions
            {
                Compress = true,
                VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = canvas.Size }
            };
            canvas.Save(svgzPath, svgOptions);
        }

        // Load SVGZ and rasterize to PNG
        using (Image svgImage = Image.Load(svgzPath))
        {
            PngOptions pngOptions = new PngOptions();
            svgImage.Save(pngPath, pngOptions);
        }
    }
}