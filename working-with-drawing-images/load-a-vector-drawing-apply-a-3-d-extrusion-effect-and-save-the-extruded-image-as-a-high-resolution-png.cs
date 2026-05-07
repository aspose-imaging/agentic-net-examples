using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

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
                    PageSize = new SizeF(vectorImage.Width * 4, vectorImage.Height * 4)
                };

                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                using (MemoryStream ms = new MemoryStream())
                {
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        int extrudeDepth = 20;
                        int canvasWidth = raster.Width + extrudeDepth;
                        int canvasHeight = raster.Height + extrudeDepth;

                        var canvasOptions = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };

                        using (Image canvasImage = Image.Create(canvasOptions, canvasWidth, canvasHeight))
                        {
                            using (RasterImage canvasRaster = (RasterImage)canvasImage)
                            {
                                int totalPixels = canvasWidth * canvasHeight;
                                int[] whitePixels = new int[totalPixels];
                                for (int i = 0; i < totalPixels; i++)
                                {
                                    whitePixels[i] = unchecked((int)0xFFFFFFFF);
                                }
                                canvasRaster.SaveArgb32Pixels(new Rectangle(0, 0, canvasWidth, canvasHeight), whitePixels);

                                for (int offset = extrudeDepth; offset > 0; offset--)
                                {
                                    canvasRaster.Blend(new Point(offset, offset), raster, 50);
                                }

                                canvasRaster.Blend(new Point(0, 0), raster, 255);

                                canvasRaster.Save();
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