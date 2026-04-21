using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\Temp\output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 600;

            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Indexed;
            psdOptions.CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE;
            psdOptions.ChannelBitsCount = 8;
            psdOptions.ChannelsCount = (short)1;
            psdOptions.Version = 6;

            using (Image image = Image.Create(psdOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                graphics.DrawLine(new Pen(Color.Red, 3), new Point(50, 50), new Point(750, 50));
                graphics.DrawRectangle(new Pen(Color.Green, 2), new Rectangle(100, 100, 200, 150));

                using (SolidBrush blueBrush = new SolidBrush())
                {
                    blueBrush.Color = Color.Blue;
                    graphics.FillEllipse(blueBrush, new Rectangle(350, 100, 200, 150));
                }

                Point[] trianglePoints = new Point[]
                {
                    new Point(200, 300),
                    new Point(400, 300),
                    new Point(300, 450)
                };
                graphics.DrawPolygon(new Pen(Color.Purple, 2), trianglePoints);

                using (SolidBrush orangeBrush = new SolidBrush())
                {
                    orangeBrush.Color = Color.Orange;
                    graphics.FillRectangle(orangeBrush, new Rectangle(500, 300, 150, 100));
                }

                graphics.DrawArc(new Pen(Color.Brown, 2), new Rectangle(100, 400, 200, 100), 0, 180);

                using (SolidBrush tealBrush = new SolidBrush())
                {
                    tealBrush.Color = Color.Teal;
                    graphics.FillPie(tealBrush, new Rectangle(350, 400, 200, 100), 45, 270);
                }

                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}