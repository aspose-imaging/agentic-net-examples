using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files
        string[] jpgPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output intermediate SVGZ and final PNG paths
        string svgzPath = "combined.svgz";
        string pngPath = "combined.png";

        // Collect sizes of all JPG images
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (Aspose.Imaging.Size sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Create SVG canvas
        int dpi = 96;
        SvgGraphics2D svgGraphics = new SvgGraphics2D(totalWidth, maxHeight, dpi);

        // Draw each JPG onto the SVG canvas
        int offsetX = 0;
        foreach (string path in jpgPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                svgGraphics.DrawImage(img, new Aspose.Imaging.Point(offsetX, 0), new Aspose.Imaging.Size(img.Width, img.Height));
                offsetX += img.Width;
            }
        }

        // Finalize SVG and save as compressed SVGZ
        using (SvgImage svgImage = svgGraphics.EndRecording())
        {
            SvgOptions svgOptions = new SvgOptions()
            {
                Compress = true
            };
            svgImage.Save(svgzPath, svgOptions);
        }

        // Load the SVGZ and rasterize to PNG
        using (Image svgLoaded = Image.Load(svgzPath))
        {
            // Configure rasterization options matching the SVG size
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions()
            {
                PageWidth = svgLoaded.Width,
                PageHeight = svgLoaded.Height,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Configure PNG export
            PngOptions pngOptions = new PngOptions()
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the final PNG
            svgLoaded.Save(pngPath, pngOptions);
        }
    }
}