// HOW-TO: Apply Semi Transparent Red Overlay to SVG and Export PNG in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input/input.svg";
        string outputPath = "output/output.png";

        byte overlayA = 128;
        byte overlayR = 255;
        byte overlayG = 0;
        byte overlayB = 0;

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

                Source outSource = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = outSource };

                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(vectorImage, 0, 0);

                    Rectangle bounds = new Rectangle(0, 0, width, height);
                    int[] pixels = canvas.LoadArgb32Pixels(bounds);
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int src = pixels[i];
                        byte srcA = (byte)((src >> 24) & 0xFF);
                        byte srcR = (byte)((src >> 16) & 0xFF);
                        byte srcG = (byte)((src >> 8) & 0xFF);
                        byte srcB = (byte)(src & 0xFF);

                        float alpha = overlayA / 255f;
                        byte resR = (byte)(overlayR * alpha + srcR * (1 - alpha));
                        byte resG = (byte)(overlayG * alpha + srcG * (1 - alpha));
                        byte resB = (byte)(overlayB * alpha + srcB * (1 - alpha));
                        byte resA = srcA;

                        pixels[i] = (resA << 24) | (resR << 16) | (resG << 8) | resB;
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
 * 1. When you need to add a brand‑color tint to an SVG logo before delivering it as a PNG for web use.
 * 2. When generating product thumbnails that require a semi‑transparent red highlight over vector artwork.
 * 3. When creating watermarked PNGs by overlaying a custom RGBA color onto scalable graphics.
 * 4. When converting SVG icons to PNG sprites while applying a uniform color filter for theming.
 * 5. When preprocessing vector diagrams for PDF reports by rasterizing them with a colored overlay and saving as PNG.
 */
