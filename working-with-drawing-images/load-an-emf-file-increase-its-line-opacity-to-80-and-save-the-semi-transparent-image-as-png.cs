// HOW-TO: Convert EMF to Semi Transparent PNG with 80% Opacity in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.emf";
        string outputPath = "Output/transparent.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emf = (EmfImage)Image.Load(inputPath))
            {
                int width = emf.Width;
                int height = emf.Height;

                using (PngImage png = new PngImage(width, height, PngColorType.TruecolorWithAlpha))
                {
                    Graphics graphics = new Graphics(png);
                    graphics.Clear(Color.Transparent);
                    graphics.DrawImage(emf, new Rectangle(0, 0, width, height));

                    int[] pixels = png.LoadArgb32Pixels(new Rectangle(0, 0, width, height));
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int argb = pixels[i];
                        int a = (argb >> 24) & 0xFF;
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;
                        a = (int)(a * 0.8);
                        pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                    }
                    png.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);
                    png.Save(outputPath);
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
 * 1. When you need to embed vector graphics from an EMF file into a web page with a uniform 80% transparency effect.
 * 2. When generating report thumbnails where the original EMF diagram should appear slightly faded over a background.
 * 3. When creating UI icons that require a consistent semi‑transparent look derived from existing EMF assets.
 * 4. When preparing print‑ready PDFs that include PNG overlays with reduced opacity to blend with other layers.
 * 5. When converting legacy EMF diagrams to PNG for mobile apps while applying a uniform transparency to match the app’s design theme.
 */
