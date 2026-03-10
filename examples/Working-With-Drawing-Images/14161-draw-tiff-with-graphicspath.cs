using System;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        using (var image = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
        {
            var graphicsPath = PathResourceConverter.ToGraphicsPath(
                image.ActiveFrame.PathResources.ToArray(),
                image.ActiveFrame.Size);

            var graphics = new Aspose.Imaging.Graphics(image);
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 5), graphicsPath);
            image.Save(outputPath);
        }
    }
}