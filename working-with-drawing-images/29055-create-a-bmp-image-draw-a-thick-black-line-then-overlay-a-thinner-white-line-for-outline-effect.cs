using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(stream);
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 300))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                Aspose.Imaging.Pen blackPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 10);
                graphics.DrawLine(blackPen, new Aspose.Imaging.Point(50, 150), new Aspose.Imaging.Point(350, 150));
                Aspose.Imaging.Pen whitePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.White, 2);
                graphics.DrawLine(whitePen, new Aspose.Imaging.Point(50, 150), new Aspose.Imaging.Point(350, 150));
                image.Save();
            }
        }
    }
}