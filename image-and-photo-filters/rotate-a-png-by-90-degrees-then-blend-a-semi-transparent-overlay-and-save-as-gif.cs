using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Rotate PNG by 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                int width = image.Width;
                int height = image.Height;

                // Create a semi‑transparent red overlay
                string overlayTempPath = "overlay_temp.png";
                Source overlaySource = new FileCreateSource(overlayTempPath, false);
                PngOptions overlayOptions = new PngOptions { Source = overlaySource };

                using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, width, height))
                {
                    int[] pixels = new int[width * height];
                    int argb = (128 << 24) | (255 << 16) | (0 << 8) | 0; // 50% opaque red
                    for (int i = 0; i < pixels.Length; i++)
                        pixels[i] = argb;

                    overlay.SaveArgb32Pixels(overlay.Bounds, pixels);

                    // Blend overlay onto the rotated image
                    image.Blend(new Point(0, 0), overlay, 255);
                }

                // Save the result as GIF
                GifOptions gifOptions = new GifOptions { Source = new FileCreateSource(outputPath, false) };
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}