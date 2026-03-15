using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files to be combined.
        string[] inputFiles = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output PNG file.
        string outputFile = "combined.png";

        // Collect sizes of all input images.
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal concatenation).
        int totalWidth = sizes.Sum(s => s.Width);
        int maxHeight = sizes.Max(s => s.Height);

        // Create an SVG canvas with the calculated dimensions.
        int dpi = 96;
        SvgGraphics2D svgGraphics = new SvgGraphics2D(totalWidth, maxHeight, dpi);

        // Draw each JPG onto the SVG canvas.
        int offsetX = 0;
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                svgGraphics.DrawImage(img, new Aspose.Imaging.Point(offsetX, 0), new Aspose.Imaging.Size(img.Width, img.Height));
                offsetX += img.Width;
            }
        }

        // Finalize SVG and rasterize to PNG.
        using (SvgImage svgImage = svgGraphics.EndRecording())
        {
            // Configure rasterization options for SVG to PNG conversion.
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = svgImage.Size;

            // Set PNG export options and attach rasterization options.
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the combined image as PNG.
            svgImage.Save(outputFile, pngOptions);
        }
    }
}