using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            Rectangle rect = raster.Bounds;
            int[] pixels = raster.LoadArgb32Pixels(rect);

            for (int i = 0; i < pixels.Length; i++)
            {
                int argb = pixels[i];
                int a = (argb >> 24) & 0xFF;
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;

                r = 255 - r;
                g = 255 - g;
                b = 255 - b;

                pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
            }

            raster.SaveArgb32Pixels(rect, pixels);

            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = raster.Size
                }
            };

            image.Save(outputPath, svgOptions);
        }
    }
}