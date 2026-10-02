// HOW-TO: Blend Semi Transparent Rectangle Onto GIF Background In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage background = (GifImage)Image.Load(inputPath))
            {
                string overlayTempPath = Path.Combine(Path.GetTempPath(), "overlay_temp.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(overlayTempPath));
                Source overlaySource = new FileCreateSource(overlayTempPath, false);
                BmpOptions overlayOptions = new BmpOptions() { Source = overlaySource };

                using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, 200, 150))
                {
                    Graphics graphics = new Graphics(overlay);
                    graphics.Clear(Color.FromArgb(128, 255, 0, 0));

                    int x = (background.Width - overlay.Width) / 2;
                    int y = (background.Height - overlay.Height) / 2;
                    background.Blend(new Point(x, y), overlay, 127);
                }

                GifOptions saveOptions = new GifOptions() { Source = new FileCreateSource(outputPath, false) };
                background.Save(outputPath, saveOptions);
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
 * 1. When you need to add a semi‑transparent colored banner as a watermark to an animated GIF for branding purposes.
 * 2. When you want to overlay a notification box onto a GIF frame in a web application using Aspose.Imaging for C#.
 * 3. When you must programmatically highlight a specific area of a GIF with a centered rectangle to guide users.
 * 4. When generating dynamic GIFs that display a status or progress indicator as a blended overlay.
 * 5. When creating GIF thumbnails with a colored overlay to indicate selection or focus in a UI.
 */
