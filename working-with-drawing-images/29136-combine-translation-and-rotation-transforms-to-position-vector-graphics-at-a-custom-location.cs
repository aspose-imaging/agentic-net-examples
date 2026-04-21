using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.emf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (EmfImage sourceEmf = (EmfImage)Image.Load(inputPath))
        {
            int canvasWidth = sourceEmf.Width + 200;
            int canvasHeight = sourceEmf.Height + 200;

            Rectangle frame = new Rectangle(0, 0, canvasWidth, canvasHeight);
            Size deviceSize = new Size(canvasWidth, canvasHeight);
            Size deviceSizeMm = new Size(canvasWidth / 100, canvasHeight / 100);

            EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(frame, deviceSize, deviceSizeMm);

            Matrix transform = new Matrix();
            transform.Translate(100, 50);
            transform.Rotate(45);
            graphics.SetTransform(transform);

            using (MemoryStream ms = new MemoryStream())
            {
                sourceEmf.Save(ms, new PngOptions());
                ms.Position = 0;
                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    graphics.DrawImage(raster, new Point(0, 0));
                }
            }

            using (EmfImage resultEmf = graphics.EndRecording())
            {
                resultEmf.Save(outputPath);
            }
        }
    }
}