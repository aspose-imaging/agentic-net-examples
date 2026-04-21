using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.svg");

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".png");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                // Prepare PNG options for rasterization
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    BitDepth = 8,
                    Source = new FileCreateSource(outputPath, false)
                };

                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = new SizeF(svgImage.Width, svgImage.Height)
                };
                pngOptions.VectorRasterizationOptions = vectorOptions;

                // Rasterize SVG to a temporary raster image
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        int offset = 5;
                        int canvasWidth = raster.Width + offset;
                        int canvasHeight = raster.Height + offset;

                        // Create canvas with bound output file
                        using (Image canvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
                        {
                            // Draw shadow and original image
                            Graphics graphics = new Graphics(canvas);
                            graphics.Clear(Color.Transparent);

                            using (SolidBrush shadowBrush = new SolidBrush())
                            {
                                shadowBrush.Color = Color.FromArgb(128, 0, 0, 0);
                                graphics.FillRectangle(shadowBrush, offset, offset, raster.Width, raster.Height);
                            }

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