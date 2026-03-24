using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                image.ActiveFrame.PathResources.ToArray(),
                image.ActiveFrame.Size);

            Graphics graphics = new Graphics(image);
            graphics.DrawPath(new Pen(Color.Red, 5), graphicsPath);

            image.Save(outputPath);
        }
    }
}