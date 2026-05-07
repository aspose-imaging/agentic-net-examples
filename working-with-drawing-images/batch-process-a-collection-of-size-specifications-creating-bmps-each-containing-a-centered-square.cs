using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var specs = new (int width, int height)[]
            {
                (200, 200),
                (300, 150),
                (400, 300)
            };

            foreach (var spec in specs)
            {
                int width = spec.width;
                int height = spec.height;

                string outputPath = Path.Combine("Output", $"image_{width}x{height}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                FileCreateSource source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions
                {
                    Source = source,
                    BitsPerPixel = 24
                };

                using (BmpImage canvas = (BmpImage)Aspose.Imaging.Image.Create(options, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);

                    int squareSize = Math.Min(width, height) / 2;
                    int offsetX = (width - squareSize) / 2;
                    int offsetY = (height - squareSize) / 2;

                    using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                    {
                        graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(offsetX, offsetY, squareSize, squareSize));
                    }

                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}