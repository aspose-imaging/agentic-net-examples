using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files to merge
        string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Output merged JPEG file
        string outputPath = "merged.jpg";

        // Collect sizes of input images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal merge
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (var sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Create SVG canvas
        int dpi = 96;
        SvgGraphics2D svgGraphics = new SvgGraphics2D(totalWidth, maxHeight, dpi);

        // Draw each JPEG onto the SVG canvas
        int offsetX = 0;
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                svgGraphics.DrawImage(img, new Aspose.Imaging.Point(offsetX, 0), new Aspose.Imaging.Size(img.Width, img.Height));
                offsetX += img.Width;
            }
        }

        // Finalize SVG image
        using (SvgImage svgImage = svgGraphics.EndRecording())
        {
            // Prepare JPEG options with rasterization settings
            JpegOptions jpegOptions = new JpegOptions();
            jpegOptions.VectorRasterizationOptions = new SvgRasterizationOptions() { PageSize = svgImage.Size };
            // Save merged image as JPEG
            svgImage.Save(outputPath, jpegOptions);
        }
    }
}