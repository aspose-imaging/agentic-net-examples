// HOW-TO: Add Text Watermark to BMP After SVG Rasterization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputSvgPath = "input.svg";
            string outputBmpPath = "output.bmp";

            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputBmpPath));

            // Load SVG and rasterize to BMP
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                var svg = (Aspose.Imaging.FileFormats.Svg.SvgImage)svgImage;

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svg.Width,
                        PageHeight = svg.Height,
                        BackgroundColor = Color.White
                    }
                };

                svgImage.Save(outputBmpPath, bmpOptions);
            }

            // Load the rasterized BMP and add watermark
            using (Image bmpImage = Image.Load(outputBmpPath))
            {
                var raster = (RasterImage)bmpImage;
                var graphics = new Graphics(raster);

                var font = new Font("Arial", 36);
                using (var brush = new SolidBrush(Color.Yellow))
                {
                    graphics.DrawString("Watermark", font, brush, new Point(10, 10));
                }

                raster.Save(outputBmpPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert an SVG logo to a BMP file and embed a copyright notice directly onto the image in a .NET application.
 * 2. When generating printable bitmap assets from vector graphics and you must add branding text before saving them to disk.
 * 3. When automating batch processing of SVG icons to BMP format while applying a visible watermark for security or tracking purposes.
 * 4. When creating thumbnails of vector drawings in BMP format and want to overlay a label or disclaimer using Aspose.Imaging’s drawing API.
 * 5. When integrating image conversion and watermarking into a C# service that prepares graphics for legacy systems that only accept BMP files.
 */
