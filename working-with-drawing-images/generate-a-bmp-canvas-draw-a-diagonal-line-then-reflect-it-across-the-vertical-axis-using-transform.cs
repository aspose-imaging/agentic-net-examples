using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            FileCreateSource source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            using (BmpImage canvas = (BmpImage)Aspose.Imaging.Image.Create(options, 200, 200))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);

                graphics.DrawLine(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(200, 200));

                graphics.ScaleTransform(-1, 1);
                graphics.TranslateTransform(200, 0);

                graphics.DrawLine(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2),
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(200, 200));

                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}