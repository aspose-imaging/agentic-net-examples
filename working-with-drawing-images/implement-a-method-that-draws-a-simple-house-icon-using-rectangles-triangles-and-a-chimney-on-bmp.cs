using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"c:\temp\house.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, 300, 300))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // House body
            using (SolidBrush bodyBrush = new SolidBrush(Color.LightGray))
            {
                graphics.FillRectangle(bodyBrush, new Rectangle(50, 150, 200, 150));
            }
            graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(50, 150, 200, 150));

            // Roof
            Point[] roofPoints = new Point[]
            {
                new Point(50, 150),
                new Point(150, 80),
                new Point(250, 150)
            };
            using (SolidBrush roofBrush = new SolidBrush(Color.Brown))
            {
                graphics.FillPolygon(roofBrush, roofPoints);
            }
            graphics.DrawPolygon(new Pen(Color.Black, 2), roofPoints);

            // Door
            using (SolidBrush doorBrush = new SolidBrush(Color.SaddleBrown))
            {
                graphics.FillRectangle(doorBrush, new Rectangle(120, 230, 40, 70));
            }
            graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(120, 230, 40, 70));

            // Chimney
            using (SolidBrush chimneyBrush = new SolidBrush(Color.DarkRed))
            {
                graphics.FillRectangle(chimneyBrush, new Rectangle(190, 90, 30, 40));
            }
            graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(190, 90, 30, 40));

            image.Save();
        }
    }
}