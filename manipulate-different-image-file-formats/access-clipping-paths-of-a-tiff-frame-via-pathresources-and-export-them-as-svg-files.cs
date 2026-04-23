using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        string inputPath = "input.tif";
        string outputDir = "output_paths";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputDir);

        try
        {
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                var pathResources = tiffImage.ActiveFrame.PathResources;
                int index = 0;
                foreach (var pathResource in pathResources)
                {
                    var graphicsPath = PathResourceConverter.ToGraphicsPath(new[] { pathResource }, tiffImage.ActiveFrame.Size);

                    var svgOptions = new SvgOptions();
                    string outputPath = Path.Combine(outputDir, $"path_{index}.svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image svgImage = Image.Create(svgOptions, tiffImage.ActiveFrame.Width, tiffImage.ActiveFrame.Height))
                    {
                        var graphics = new Graphics(svgImage);
                        graphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);
                        svgImage.Save(outputPath);
                    }

                    index++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}