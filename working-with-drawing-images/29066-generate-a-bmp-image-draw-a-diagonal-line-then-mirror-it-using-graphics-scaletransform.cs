using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "Output/diagonal_mirror.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int width = 200;
        int height = 200;

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
        {
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Draw original diagonal line
            graphics.DrawLine(
                new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                new Aspose.Imaging.Point(0, 0),
                new Aspose.Imaging.Point(width - 1, height - 1));

            // Mirror horizontally using scale and translate transforms
            graphics.ScaleTransform(-1, 1);
            graphics.TranslateTransform(width, 0);
            graphics.DrawLine(
                new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                new Aspose.Imaging.Point(0, 0),
                new Aspose.Imaging.Point(width - 1, height - 1));

            image.Save();
        }
    }
}