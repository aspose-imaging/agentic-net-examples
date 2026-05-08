using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\drawing.svg";
            string outputPath = "Output\\billboard.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                using (var ms = new MemoryStream())
                {
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        int canvasWidth = raster.Width + 200;
                        int canvasHeight = raster.Height + 200;

                        var canvasOptions = new PngOptions
                        {
                            Source = new StreamSource(new MemoryStream())
                        };

                        using (Image canvas = Image.Create(canvasOptions, canvasWidth, canvasHeight))
                        {
                            Graphics graphics = new Graphics(canvas);
                            graphics.Clear(Color.White);

                            int offsetX = 100;
                            int offsetY = 100;

                            graphics.DrawImage(raster, new Point(offsetX, offsetY));

                            canvas.Save(outputPath, pngOptions);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}