using System;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        using (var image = (TiffImage)Aspose.Imaging.Image.Load("input.tif"))
        {
            var graphicsPath = new Aspose.Imaging.GraphicsPath();

            var graphics = new Aspose.Imaging.Graphics(image);
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5), graphicsPath);

            image.Save("output.tif");
        }
    }
}