// HOW-TO: Invert Colors of EPS and Save as High Quality JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (RasterImage raster = (RasterImage)Image.Create(pngOptions, epsImage.Width, epsImage.Height))
                {
                    int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
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

                    raster.SaveArgb32Pixels(raster.Bounds, pixels);

                    var jpegOptions = new JpegOptions
                    {
                        Quality = 100
                    };

                    raster.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a negative‑style preview of a vector EPS logo for a web gallery and deliver it as a high‑quality JPEG.
 * 2. When an e‑commerce platform must display product illustrations with inverted colors to match a dark theme, converting EPS assets to JPEG on the fly.
 * 3. When a printing workflow requires a color‑inverted raster version of an EPS artwork for proofing, and the result must be saved with maximum JPEG quality.
 * 4. When a mobile app downloads EPS icons, applies a color inversion filter for accessibility, and stores them as JPEGs for faster rendering.
 * 5. When a batch‑processing script has to convert multiple EPS files to JPEG while applying a global color inversion to meet brand guidelines.
 */
