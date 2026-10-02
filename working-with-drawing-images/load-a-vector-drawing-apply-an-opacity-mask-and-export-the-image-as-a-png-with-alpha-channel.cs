// HOW-TO: Apply 50% Opacity Mask to SVG and Save as PNG with Alpha in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
                }, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(vectorImage, new Rectangle(0, 0, width, height));

                    Rectangle bounds = new Rectangle(0, 0, width, height);
                    int[] pixels = canvas.LoadArgb32Pixels(bounds);
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int argb = pixels[i];
                        int a = 128; // 50% opacity
                        int rgb = argb & 0x00FFFFFF;
                        pixels[i] = (a << 24) | rgb;
                    }
                    canvas.SaveArgb32Pixels(bounds, pixels);

                    canvas.Save();
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
 * 1. When you need to load an SVG file in C#, apply a 50% opacity mask, and export it as a PNG with an alpha channel for web overlays.
 * 2. When generating semi‑transparent thumbnails of vector drawings using Aspose.Imaging for C# to display in a UI gallery.
 * 3. When converting vector icons to PNG assets with consistent transparency for mobile app skins using the Aspose.Imaging library.
 * 4. When creating watermarked graphics by applying a uniform opacity mask to a vector diagram before saving the result as a PNG in C#.
 * 5. When preparing layered compositions that require PNG images with an alpha channel, such as compositing SVG artwork in a desktop application.
 */
