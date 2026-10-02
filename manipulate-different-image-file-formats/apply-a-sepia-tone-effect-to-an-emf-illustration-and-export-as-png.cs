// HOW-TO: Apply Sepia Tone to EMF and Save as PNG in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image emfImage = Image.Load(inputPath))
            {
                int width = emfImage.Width;
                int height = emfImage.Height;

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
                {
                    // Draw EMF onto raster canvas
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(emfImage, new Rectangle(0, 0, width, height));

                    // Apply sepia tone
                    Rectangle bounds = new Rectangle(0, 0, width, height);
                    int[] pixels = canvas.LoadArgb32Pixels(bounds);
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int pixel = pixels[i];
                        int a = (pixel >> 24) & 0xFF;
                        int r = (pixel >> 16) & 0xFF;
                        int g = (pixel >> 8) & 0xFF;
                        int b = pixel & 0xFF;

                        int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                        int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                        int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                        tr = tr > 255 ? 255 : tr;
                        tg = tg > 255 ? 255 : tg;
                        tb = tb > 255 ? 255 : tb;

                        pixels[i] = (a << 24) | (tr << 16) | (tg << 8) | tb;
                    }
                    canvas.SaveArgb32Pixels(bounds, pixels);

                    // Save the final PNG
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
 * 1. When you need to convert legacy vector EMF illustrations to web‑friendly PNGs with a nostalgic sepia effect for a marketing website.
 * 2. When generating thumbnail previews of EMF diagrams for a desktop application and want the thumbnails to have a consistent sepia style.
 * 3. When preparing printed reports that embed EMF charts but require the images to be saved as PNG with a sepia tone to match a vintage theme.
 * 4. When automating batch processing of EMF assets in a CI pipeline and need to apply a sepia filter before publishing them as PNG files.
 * 5. When creating an e‑learning module that displays EMF graphics with a sepia look, and you must programmatically render them to PNG for cross‑platform compatibility.
 */
