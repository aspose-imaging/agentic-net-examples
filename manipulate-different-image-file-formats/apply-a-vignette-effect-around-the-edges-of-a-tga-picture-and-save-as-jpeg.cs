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
        string inputPath = "input.tga";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            JpegOptions jpegOptions = new JpegOptions();
            jpegOptions.Quality = 90;
            jpegOptions.Source = new FileCreateSource(outputPath, false);

            using (Image canvas = Image.Create(jpegOptions, sourceImage.Width, sourceImage.Height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.DrawImage(sourceImage, new Rectangle(0, 0, sourceImage.Width, sourceImage.Height));

                SolidBrush vignetteBrush = new SolidBrush(Color.FromArgb(80, 0, 0, 0));
                graphics.FillRectangle(vignetteBrush, canvas.Bounds);

                canvas.Save();
            }
        }
    }
}