using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Console.WriteLine("Select watermark removal algorithm:");
            Console.WriteLine("1 - Telea");
            Console.WriteLine("2 - Content Aware Fill");
            Console.Write("Enter choice (1 or 2): ");
            string choice = Console.ReadLine();

            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
            mask.AddFigure(figure);

            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;
                RasterImage result;

                if (choice == "1")
                {
                    var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                    result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options);
                }
                else
                {
                    var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = 4
                    };
                    result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options);
                }

                using (result)
                {
                    result.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}