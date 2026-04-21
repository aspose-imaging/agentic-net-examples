using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = "input.emf";
        string tempPath = "temp.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EMF and rasterize to a temporary PNG
        using (Image emfImage = Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Color.White
                },
                Source = new FileCreateSource(tempPath, false)
            };
            emfImage.Save(pngOptions);
        }

        // Load the rasterized PNG and apply sepia tone
        using (RasterImage raster = (RasterImage)Image.Load(tempPath))
        {
            int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
            for (int i = 0; i < pixels.Length; i++)
            {
                int argb = pixels[i];
                int a = (argb >> 24) & 0xFF;
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;

                int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                tr = tr > 255 ? 255 : tr;
                tg = tg > 255 ? 255 : tg;
                tb = tb > 255 ? 255 : tb;

                pixels[i] = (a << 24) | (tr << 16) | (tg << 8) | tb;
            }
            raster.SaveArgb32Pixels(raster.Bounds, pixels);

            // Save the final PNG with sepia effect
            var finalOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            raster.Save(finalOptions);
        }
    }
}