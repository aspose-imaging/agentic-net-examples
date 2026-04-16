using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input SVG and output BMP paths
        string inputSvgPath = "input.svg";
        string outputBmpPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputSvgPath))
        {
            Console.Error.WriteLine($"File not found: {inputSvgPath}");
            return;
        }

        // Ensure output directory exists (unconditional call as per requirements)
        Directory.CreateDirectory(Path.GetDirectoryName(outputBmpPath));

        // Load SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(inputSvgPath))
        {
            // Set up rasterization options for BMP output
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to a memory stream
            using (var ms = new MemoryStream())
            {
                svgImage.Save(ms, bmpOptions);
                ms.Position = 0;

                // Load rasterized image as RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                {
                    // Draw watermark text using Graphics
                    Graphics graphics = new Graphics(rasterImage);
                    graphics.DrawString(
                        "Watermark",
                        new Font("Arial", 24, FontStyle.Bold),
                        new SolidBrush(Color.FromArgb(128, 255, 255, 255)),
                        new PointF(10, 10));

                    // Save final BMP with watermark
                    rasterImage.Save(outputBmpPath, new BmpOptions());
                }
            }
        }
    }
}