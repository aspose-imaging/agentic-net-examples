using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.bmp";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Aspose.Imaging.RasterImage bmp = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int width = bmp.Width;
                int height = bmp.Height;

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, 96);

                Aspose.Imaging.Pen dashPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                dashPen.DashPattern = new float[] { 5, 5 };

                graphics.DrawImage(bmp, new Aspose.Imaging.Point(0, 0));
                graphics.DrawRectangle(dashPen, 0, 0, width, height);

                using (SvgImage svg = graphics.EndRecording())
                {
                    svg.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}