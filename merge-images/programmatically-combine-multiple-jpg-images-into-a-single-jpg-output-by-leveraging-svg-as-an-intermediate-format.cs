using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files to combine
        string[] inputFiles = { "image1.jpg", "image2.jpg", "image3.jpg" };
        string outputJpeg = "combined.jpg";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int totalWidth = sizes.Sum(s => s.Width);
        int maxHeight = sizes.Max(s => s.Height);

        // Create an SVG canvas
        SvgGraphics2D svgGraphics = new SvgGraphics2D(totalWidth, maxHeight, 96);

        // Draw each JPEG onto the SVG canvas
        int offsetX = 0;
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                svgGraphics.DrawImage(img, new Point(offsetX, 0), new Size(img.Width, img.Height));
                offsetX += img.Width;
            }
        }

        // Finalize SVG and save directly as JPEG using vector rasterization options
        using (SvgImage svgImage = svgGraphics.EndRecording())
        {
            // Set up rasterization options (default DPI)
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // Configure JPEG output options
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputJpeg, false),
                Quality = 90,
                VectorRasterizationOptions = rasterOptions
            };

            // Save the combined image as JPEG
            svgImage.Save(outputJpeg, jpegOptions);
        }
    }
}