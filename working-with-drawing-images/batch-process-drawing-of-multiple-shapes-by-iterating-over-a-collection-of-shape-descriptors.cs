using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image inputImage = Aspose.Imaging.Image.Load(inputPath))
        {
            int width = inputImage.Width;
            int height = inputImage.Height;

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image canvas = Aspose.Imaging.Image.Create(pngOptions, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);

                graphics.DrawImage((Aspose.Imaging.RasterImage)inputImage, new Aspose.Imaging.Point(0, 0));

                graphics.DrawRectangle(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3),
                    new Aspose.Imaging.Rectangle(50, 50, 200, 100));

                graphics.DrawEllipse(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3),
                    new Aspose.Imaging.Rectangle(300, 200, 150, 150));

                graphics.DrawLine(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 2),
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(width - 1, height - 1));

                canvas.Save();
            }
        }
    }
}