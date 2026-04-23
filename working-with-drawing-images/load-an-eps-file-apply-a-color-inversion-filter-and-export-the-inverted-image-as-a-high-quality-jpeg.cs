using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var pngOptions = new PngOptions();
            using (RasterImage raster = (RasterImage)Image.Create(pngOptions, image.Width, image.Height))
            {
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                int[] invertedPixels = new int[pixels.Length];

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

                    invertedPixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                }

                raster.SaveArgb32Pixels(raster.Bounds, invertedPixels);

                var jpegOptions = new JpegOptions { Quality = 100 };
                raster.Save(outputPath, jpegOptions);
            }
        }
    }
}