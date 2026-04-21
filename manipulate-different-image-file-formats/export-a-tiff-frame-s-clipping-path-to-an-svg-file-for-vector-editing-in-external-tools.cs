using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                var graphicsPath = PathResourceConverter.ToGraphicsPath(
                    tiff.ActiveFrame.PathResources.ToArray(),
                    tiff.ActiveFrame.Size);

                var svgOptions = new SvgOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Image svgImage = Image.Create(svgOptions, tiff.Width, tiff.Height))
                {
                    var graphics = new Graphics(svgImage);
                    graphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);
                    svgImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}