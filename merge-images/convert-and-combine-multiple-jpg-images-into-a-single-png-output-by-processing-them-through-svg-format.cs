using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Input JPG files
        string[] inputPaths = new string[]
        {
            "C:\\Images\\img1.jpg",
            "C:\\Images\\img2.jpg",
            "C:\\Images\\img3.jpg"
        };

        // Output PNG file
        string outputPath = "C:\\Images\\combined.png";

        // Verify each input file exists
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (var path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal concatenation)
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

        // Draw each JPG onto the SVG canvas
        int offsetX = 0;
        for (int i = 0; i < inputPaths.Length; i++)
        {
            using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
            {
                svgGraphics.DrawImage(img, new Point(offsetX, 0));
                offsetX += img.Width;
            }
        }

        // Finalize SVG and rasterize to PNG
        using (SvgImage svgImage = svgGraphics.EndRecording())
        {
            // Set up rasterization options
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = svgImage.Size;

            // Configure PNG save options
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the combined image as PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}