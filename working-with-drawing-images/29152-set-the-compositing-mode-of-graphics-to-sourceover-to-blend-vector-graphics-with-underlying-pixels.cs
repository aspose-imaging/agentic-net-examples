using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string outputPath = @"C:\temp\output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        FileCreateSource source = new FileCreateSource(outputPath, false);
        PngOptions options = new PngOptions() { Source = source };
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, 500, 500))
        {
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);
            graphics.DrawRectangle(
                new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5),
                new Aspose.Imaging.Rectangle(50, 50, 200, 150));
            image.Save();
        }
    }
}