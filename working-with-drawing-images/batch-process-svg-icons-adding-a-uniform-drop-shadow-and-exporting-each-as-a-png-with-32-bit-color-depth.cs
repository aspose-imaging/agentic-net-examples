using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputDir = "C:\\InputSvgs";
        string outputDir = "C:\\OutputPngs";

        if (!Directory.Exists(inputDir))
        {
            Directory.CreateDirectory(inputDir);
            Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
            return;
        }

        Directory.CreateDirectory(outputDir);

        string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");
        foreach (string inputPath in svgFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileName + ".png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                PngOptions pngOptions = new PngOptions();
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

                        PngOptions canvasOptions = new PngOptions();
                        canvasOptions.Source = new FileCreateSource(outputPath, false);

                        using (Image canvas = Image.Create(canvasOptions, canvasWidth, canvasHeight))
                        {
                            // Graphics does not implement IDisposable; do not wrap in using
                            Graphics graphics = new Graphics(canvas);
                            graphics.Clear(Color.Transparent);

                            // Draw shadow rectangle
                            using (SolidBrush shadowBrush = new SolidBrush(Color.Black))
                            {
                                shadowBrush.Opacity = 50; // 50% opacity
                                graphics.FillRectangle(shadowBrush, shadowOffset, shadowOffset, raster.Width, raster.Height);
                            }

                            // Draw original raster image on top
                            graphics.DrawImage(raster, new Point(0, 0));

                            // Save the final PNG
                            canvas.Save();
                        }
                    }
                }
            }
        }
    }
}