using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/clipPath.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var tiffImage = (TiffImage)Image.Load(inputPath))
            {
                var graphicsPath = PathResourceConverter.ToGraphicsPath(
                    tiffImage.ActiveFrame.PathResources.ToArray(),
                    tiffImage.ActiveFrame.Size);

                var svgOptions = new SvgOptions();
                using (var svgImage = (SvgImage)Image.Create(svgOptions, tiffImage.Width, tiffImage.Height))
                {
                    var graphics = new Graphics(svgImage);
                    graphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);
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