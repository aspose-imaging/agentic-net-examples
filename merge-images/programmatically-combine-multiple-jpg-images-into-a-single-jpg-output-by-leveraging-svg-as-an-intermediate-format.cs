using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG paths
        string[] inputPaths = {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Hardcoded output JPG path
        string outputPath = @"C:\Images\combined.jpg";

        // Temporary SVG file path
        string tempSvgPath = @"C:\Images\temp.svg";

        // Validate input files
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempSvgPath));

        // Collect sizes to determine canvas dimensions (horizontal concatenation)
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        int totalWidth = 0;
        int maxHeight = 0;
        foreach (Size sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Create an SVG canvas with calculated dimensions
        using (SvgImage svgCanvas = new SvgImage(totalWidth, maxHeight))
        {
            // Draw each JPG onto the SVG canvas side by side
            int offsetX = 0;
            for (int i = 0; i < inputPaths.Length; i++)
            {
                using (RasterImage raster = (RasterImage)Image.Load(inputPaths[i]))
                {
                    Graphics graphics = new Graphics(svgCanvas);
                    Rectangle destRect = new Rectangle(offsetX, 0, raster.Width, raster.Height);
                    graphics.DrawImage(raster, destRect);
                    offsetX += raster.Width;
                }
            }

            // Save the intermediate SVG file
            svgCanvas.Save(tempSvgPath);
        }

        // Load the SVG and rasterize to JPEG using vector rasterization options
        using (Image svgImage = Image.Load(tempSvgPath))
        {
            // Configure SVG rasterization options
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // Configure JPEG save options with rasterization
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100,
                VectorRasterizationOptions = rasterOptions
            };

            // Save the final JPEG image
            svgImage.Save(outputPath, jpegOptions);
        }
    }
}