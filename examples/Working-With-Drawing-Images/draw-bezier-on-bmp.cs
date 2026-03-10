using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "bezier.bmp";
        int width = 500;
        int height = 500;

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, width, height))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            Pen pen = new Pen(Color.Blue, 2);
            graphics.DrawBezier(pen,
                new Point(50, 400),   // start point
                new Point(150, 100),  // first control point
                new Point(350, 100),  // second control point
                new Point(450, 400)   // end point
            );

            image.Save();
        }
    }
}