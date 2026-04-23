using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";
        string tempPath = "temp.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? ".");

            using (Image emfImage = Image.Load(inputPath))
            {
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Color.White
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Source = new FileCreateSource(tempPath, false)
                };
                emfImage.Save(tempPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    byte a = (byte)((argb >> 24) & 0xFF);
                    byte r = (byte)((argb >> 16) & 0xFF);
                    byte g = (byte)((argb >> 8) & 0xFF);
                    byte b = (byte)(argb & 0xFF);

                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    byte nr = (byte)(tr > 255 ? 255 : tr);
                    byte ng = (byte)(tg > 255 ? 255 : tg);
                    byte nb = (byte)(tb > 255 ? 255 : tb);

                    pixels[i] = (a << 24) | (nr << 16) | (ng << 8) | nb;
                }
                raster.SaveArgb32Pixels(raster.Bounds, pixels);
                var finalOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, finalOptions);
            }

            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}