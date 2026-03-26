using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputSvgPath = @"C:\Images\input.svg";
        string rasterBmpPath = @"C:\Images\rasterized.bmp";
        string outputBmpPath = @"C:\Images\watermarked.bmp";

        // Verify input SVG exists
        if (!File.Exists(inputSvgPath))
        {
            Console.Error.WriteLine($"File not found: {inputSvgPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(rasterBmpPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputBmpPath));

        // Load SVG and rasterize to BMP
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(rasterBmpPath, bmpOptions);
        }

        // Load rasterized BMP, add watermark text, and save final image
        using (Image bmpImage = Image.Load(rasterBmpPath))
        {
            var raster = (RasterImage)bmpImage;

            // Create graphics for drawing
            Graphics graphics = new Graphics(raster);

            // Prepare brush and font for watermark
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.White)))
            {
                Font font = new Font("Arial", 48, FontStyle.Regular);
                // Position watermark near bottom-left corner
                graphics.DrawString("Watermark", font, brush, new PointF(10, raster.Height - 60));
            }

            // Save the watermarked BMP
            raster.Save(outputBmpPath, new BmpOptions());
        }
    }
}