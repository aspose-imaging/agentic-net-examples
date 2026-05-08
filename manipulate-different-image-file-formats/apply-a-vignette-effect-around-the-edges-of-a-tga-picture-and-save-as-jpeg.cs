using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tga";
        string outputPath = "output/output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var bounds = image.Bounds;
                int width = bounds.Width;
                int height = bounds.Height;
                int[] pixels = image.GetDefaultArgb32Pixels(bounds);

                float centerX = width / 2f;
                float centerY = height / 2f;
                float maxDist = (float)Math.Sqrt(centerX * centerX + centerY * centerY);
                float strength = 0.5f; // vignette strength

                for (int i = 0; i < pixels.Length; i++)
                {
                    int x = i % width;
                    int y = i / width;

                    float dx = x - centerX;
                    float dy = y - centerY;
                    float dist = (float)Math.Sqrt(dx * dx + dy * dy);
                    float factor = 1f - strength * (dist / maxDist);
                    if (factor < 0f) factor = 0f;

                    int argb = pixels[i];
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;

                    r = (int)(r * factor);
                    g = (int)(g * factor);
                    b = (int)(b * factor);

                    pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                }

                image.SaveArgb32Pixels(bounds, pixels);

                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}