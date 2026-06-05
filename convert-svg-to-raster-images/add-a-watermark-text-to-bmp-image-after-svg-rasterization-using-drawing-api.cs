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
        try
        {
            // Hardcoded input and output paths
            string inputSvgPath = "input.svg";
            string tempBmpPath = "temp/temp.bmp";
            string outputBmpPath = "output/output.bmp";

            // Validate input SVG file existence
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directories exist (unconditional per requirements)
            Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputBmpPath));

            // Load SVG and rasterize to a temporary BMP file
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                var svgImg = (SvgImage)svgImage;

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImg.Size
                };

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempBmpPath, bmpOptions);
            }

            // Load the rasterized BMP, add watermark text, and save final output
            using (Image bmpImage = Image.Load(tempBmpPath))
            {
                var raster = (RasterImage)bmpImage;

                Graphics graphics = new Graphics(raster);
                var font = new Font("Arial", 24, FontStyle.Bold);
                using (SolidBrush brush = new SolidBrush(Color.Yellow))
                {
                    graphics.DrawString("Watermark", font, brush, new Point(10, 10));
                }

                // Save the final BMP with watermark
                bmpImage.Save(outputBmpPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}