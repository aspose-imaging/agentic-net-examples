using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input file paths
        string svgInputPath = @"C:\temp\input.svg";
        string bmpInputPath = @"C:\temp\source.bmp";

        // Temporary PNG path
        string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_image.png");

        // Output SVG path
        string svgOutputPath = @"C:\temp\output.svg";

        // Load BMP image
        using (RasterImage bmpImage = (RasterImage)Image.Load(bmpInputPath))
        {
            // Create PNG canvas with same dimensions as BMP
            Source pngSource = new FileCreateSource(tempPngPath, false);
            PngOptions pngOptions = new PngOptions { Source = pngSource };
            using (PngImage pngImage = (PngImage)Image.Create(pngOptions, bmpImage.Width, bmpImage.Height))
            {
                // Copy BMP pixels to PNG
                pngImage.SaveArgb32Pixels(new Rectangle(0, 0, bmpImage.Width, bmpImage.Height),
                                          bmpImage.LoadArgb32Pixels(bmpImage.Bounds));
                // Save PNG to file
                pngImage.Save();
            }
        }

        // Load the generated PNG image
        using (RasterImage pngToDraw = (RasterImage)Image.Load(tempPngPath))
        // Load the existing SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(svgInputPath))
        {
            // Create SvgGraphics2D with SVG dimensions
            SvgGraphics2D graphics = new SvgGraphics2D(svgImage.Width, svgImage.Height, 96);

            // Draw the PNG onto the SVG at position (50,50)
            graphics.DrawImage(pngToDraw, new Point(50, 50));

            // Finalize SVG drawing
            using (SvgImage resultSvg = graphics.EndRecording())
            {
                resultSvg.Save(svgOutputPath);
            }
        }

        // Clean up temporary PNG file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}