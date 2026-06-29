using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputSvgPath = "input.svg";
        string outputBmpPath = "output.bmp";

        if (!File.Exists(inputSvgPath))
        {
            Console.Error.WriteLine($"File not found: {inputSvgPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputBmpPath);
        if (!string.IsNullOrEmpty(outputDir))
            Directory.CreateDirectory(outputDir);

        try
        {
            // Load SVG and rasterize to BMP
            using (var svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)Image.Load(inputSvgPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                var bmpOptions = new BmpOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(outputBmpPath, bmpOptions);
            }

            // Load BMP and add watermark text
            using (var bmpImage = (RasterImage)Image.Load(outputBmpPath))
            {
                var graphics = new Graphics(bmpImage);
                var font = new Font("Arial", 24, FontStyle.Regular);
                using (var brush = new SolidBrush(Color.Yellow))
                {
                    graphics.DrawString("Watermark", font, brush, new Point(10, bmpImage.Height - 30));
                }
                bmpImage.Save();
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
 * 1. When a developer needs to convert an SVG logo to a BMP thumbnail and embed a copyright watermark for use in a Windows desktop application.
 * 2. When an e‑commerce platform must generate product preview images from vector SVG files and add promotional text before storing them as BMP files.
 * 3. When a reporting tool requires rasterizing SVG charts to BMP format and overlaying a “Confidential” label for secure PDF export.
 * 4. When a batch‑processing script has to automate the creation of watermarked BMP assets from SVG icons for inclusion in a legacy game engine.
 * 5. When a document management system must render SVG diagrams as BMP images and apply a dynamic watermark indicating the document version.
 */