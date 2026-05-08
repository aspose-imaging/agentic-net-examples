using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"c:\temp\venn_diagram.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Red ellipse
                using (SolidBrush brush1 = new SolidBrush())
                {
                    brush1.Color = Aspose.Imaging.Color.Red;
                    brush1.Opacity = 50;
                    graphics.FillEllipse(brush1, new Aspose.Imaging.Rectangle(50, 150, 200, 200));
                }

                // Green ellipse
                using (SolidBrush brush2 = new SolidBrush())
                {
                    brush2.Color = Aspose.Imaging.Color.Green;
                    brush2.Opacity = 50;
                    graphics.FillEllipse(brush2, new Aspose.Imaging.Rectangle(150, 150, 200, 200));
                }

                // Blue ellipse
                using (SolidBrush brush3 = new SolidBrush())
                {
                    brush3.Color = Aspose.Imaging.Color.Blue;
                    brush3.Opacity = 50;
                    graphics.FillEllipse(brush3, new Aspose.Imaging.Rectangle(100, 50, 200, 200));
                }

                // Outline the ellipses
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(50, 150, 200, 200));
                graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(150, 150, 200, 200));
                graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(100, 50, 200, 200));

                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}