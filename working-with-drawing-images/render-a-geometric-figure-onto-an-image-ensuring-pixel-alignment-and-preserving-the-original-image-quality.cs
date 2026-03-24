using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

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

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            graphics.DrawRectangle(
                new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3),
                new Aspose.Imaging.Rectangle(50, 50, 200, 150));

            using (SolidBrush brush = new SolidBrush(
                Aspose.Imaging.Color.FromArgb(128, Aspose.Imaging.Color.Blue)))
            {
                graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(60, 60, 180, 130));
            }

            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}