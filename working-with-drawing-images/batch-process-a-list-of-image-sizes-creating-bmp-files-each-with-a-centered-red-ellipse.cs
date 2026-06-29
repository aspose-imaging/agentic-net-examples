using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var sizes = new (int width, int height)[]
            {
                (200, 200),
                (400, 300),
                (800, 600)
            };

            foreach (var size in sizes)
            {
                string outputPath = $"output_{size.width}x{size.height}.bmp";

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                FileCreateSource source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

                using (Aspose.Imaging.Image canvas = Aspose.Imaging.Image.Create(options, size.width, size.height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawEllipse(
                        new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 1),
                        new Aspose.Imaging.Rectangle(0, 0, size.width, size.height));
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
 * 1. When a developer needs to generate a set of placeholder BMP images of various dimensions with a centered red ellipse for UI mock‑ups or testing layout algorithms.
 * 2. When an automated build pipeline must create thumbnail BMP assets in multiple sizes for a legacy Windows application that only supports BMP files.
 * 3. When a reporting tool requires batch creation of BMP charts where each chart is represented by a red ellipse drawn on a white background at different resolutions.
 * 4. When a game developer wants to pre‑render simple BMP sprites containing a red ellipse at several sizes to be loaded quickly at runtime.
 * 5. When a documentation generator needs to produce sample BMP images of specific widths and heights with a red ellipse to illustrate image processing examples in Aspose.Imaging tutorials.
 */