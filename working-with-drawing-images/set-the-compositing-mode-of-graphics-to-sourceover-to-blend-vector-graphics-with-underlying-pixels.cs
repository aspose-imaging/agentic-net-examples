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
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage inputImage = (RasterImage)Image.Load(inputPath))
        {
            int width = inputImage.Width;
            int height = inputImage.Height;

            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outputSource };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
            {
                canvas.SaveArgb32Pixels(new Rectangle(0, 0, width, height), inputImage.LoadArgb32Pixels(inputImage.Bounds));

                Graphics graphics = new Graphics(canvas);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Red)))
                {
                    graphics.FillRectangle(brush, new Rectangle(50, 50, 200, 150));
                }

                canvas.Save();
            }
        }
    }
}