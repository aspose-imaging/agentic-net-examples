using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = @"C:\Icons\Input";
            string outputFolder = @"C:\Icons\Output";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (var file in svgFiles)
            {
                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    var rasterOptions = new SvgRasterizationOptions();
                    rasterOptions.PageSize = svgImage.Size;

                    var pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            int shadowOffset = 5;
                            int canvasWidth = raster.Width + shadowOffset;
                            int canvasHeight = raster.Height + shadowOffset;

                            using (Image canvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
                            {
                                Graphics g = new Graphics(canvas);
                                g.Clear(Color.Transparent);

                                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0)))
                                {
                                    g.FillRectangle(shadowBrush, shadowOffset, shadowOffset, raster.Width, raster.Height);
                                }

                                g.DrawImage(raster, new Point(0, 0));

                                canvas.Save(outputPath, pngOptions);
                            }
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