using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/clipPath.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Convert clipping path resources to a GraphicsPath
                var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter
                    .ToGraphicsPath(tiffImage.ActiveFrame.PathResources.ToArray(),
                                    tiffImage.ActiveFrame.Size);

                // Create an SVG canvas and draw the path
                var svgGraphics = new SvgGraphics2D(tiffImage.Width, tiffImage.Height, 96);
                svgGraphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);

                // Finalize SVG image
                using (var svgImage = svgGraphics.EndRecording())
                {
                    svgImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}