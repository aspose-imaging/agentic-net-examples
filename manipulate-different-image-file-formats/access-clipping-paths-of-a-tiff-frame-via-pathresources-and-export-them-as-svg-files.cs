using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        string inputPath = "input.tif";
        string outputFolder = "output_paths";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputFolder);

        using (Aspose.Imaging.FileFormats.Tiff.TiffImage tiff = (Aspose.Imaging.FileFormats.Tiff.TiffImage)Aspose.Imaging.Image.Load(inputPath))
        {
            var pathResources = tiff.ActiveFrame.PathResources;
            for (int i = 0; i < pathResources.Count; i++)
            {
                var pathResource = pathResources[i];
                var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                    new[] { pathResource },
                    tiff.ActiveFrame.Size);

                using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Create(new SvgOptions(), tiff.Width, tiff.Height))
                {
                    var graphics = new Aspose.Imaging.Graphics(svgImage);
                    graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1), graphicsPath);

                    string outputPath = Path.Combine(outputFolder, $"Path_{i}.svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    svgImage.Save(outputPath);
                }
            }
        }
    }
}