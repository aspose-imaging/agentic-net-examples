using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TgaImage image = (TgaImage)Image.Load(inputPath))
            {
                int width = image.Width;
                int height = image.Height;
                Graphics graphics = new Graphics(image);

                // Apply a simple vignette by drawing concentric semi‑transparent black ellipses
                int steps = 10;
                for (int i = 0; i < steps; i++)
                {
                    float insetX = i * width / (float)(steps * 2);
                    float insetY = i * height / (float)(steps * 2);
                    float ellipseWidth = width - 2 * insetX;
                    float ellipseHeight = height - 2 * insetY;

                    int alpha = (int)(255 * (i + 1) / (float)steps * 0.5); // max 50% opacity
                    Color vignetteColor = Color.FromArgb(alpha, 0, 0, 0);
                    SolidBrush brush = new SolidBrush(vignetteColor);

                    graphics.FillEllipse(brush, new RectangleF(insetX, insetY, ellipseWidth, ellipseHeight));
                }

                JpegOptions jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}