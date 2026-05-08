using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 500;
            int height = 500;

            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    Pen pen = new Pen(Color.Blue, 2);
                    float cx = width / 2f;
                    float cy = height / 2f;
                    float r = 200f;
                    float c = r * 0.5522847498f;

                    // Top-right quarter
                    graphics.DrawBezier(pen,
                        new PointF(cx + r, cy),
                        new PointF(cx + r, cy - c),
                        new PointF(cx + c, cy - r),
                        new PointF(cx, cy - r));

                    // Top-left quarter
                    graphics.DrawBezier(pen,
                        new PointF(cx, cy - r),
                        new PointF(cx - c, cy - r),
                        new PointF(cx - r, cy - c),
                        new PointF(cx - r, cy));

                    // Bottom-left quarter
                    graphics.DrawBezier(pen,
                        new PointF(cx - r, cy),
                        new PointF(cx - r, cy + c),
                        new PointF(cx - c, cy + r),
                        new PointF(cx, cy + r));

                    // Bottom-right quarter
                    graphics.DrawBezier(pen,
                        new PointF(cx, cy + r),
                        new PointF(cx + c, cy + r),
                        new PointF(cx + r, cy + c),
                        new PointF(cx + r, cy));

                    image.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}