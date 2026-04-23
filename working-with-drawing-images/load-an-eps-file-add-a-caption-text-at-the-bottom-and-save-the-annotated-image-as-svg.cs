using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            var svgOptions = new SvgOptions();

            using (Image canvas = Image.Create(svgOptions, epsImage.Width, epsImage.Height))
            {
                var graphics = new Graphics(canvas);

                graphics.DrawImage(epsImage, new Point(0, 0));

                var font = new Font("Arial", 24, FontStyle.Regular);
                var brush = new SolidBrush(Color.Black);

                int x = epsImage.Width / 2;
                int y = epsImage.Height - 30;

                graphics.DrawString("Caption Text", font, brush, new Point(x, y));

                canvas.Save(outputPath, svgOptions);
            }
        }
    }
}