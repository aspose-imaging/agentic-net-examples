// HOW-TO: Create BMP Images with Centered Red Ellipse for Multiple Sizes in C# (Aspose.Imaging for .NET)
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
                (300, 150),
                (400, 300)
            };

            foreach (var size in sizes)
            {
                string outputPath = $"output_{size.width}x{size.height}.bmp";

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                var source = new FileCreateSource(outputPath, false);

                BmpOptions options = new BmpOptions()
                {
                    Source = source,
                    BitsPerPixel = 24
                };

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, size.width, size.height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawEllipse(
                        new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3),
                        new Aspose.Imaging.Rectangle(0, 0, size.width, size.height));
                    image.Save();
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
 * 1. When you need to generate a set of placeholder BMP files of different dimensions with a visible red ellipse for UI mock‑ups or testing image‑loading routines.
 * 2. When an automated build creates sample graphics for documentation, showing how varying image sizes affect a centered shape using Aspose.Imaging in C#.
 * 3. When a desktop application must pre‑create icons of several resolutions, each containing a red circular badge, before packaging them into a resource file.
 * 4. When a QA team requires a batch of BMP screenshots with a consistent red ellipse to verify that image‑processing pipelines preserve vector drawing fidelity across sizes.
 * 5. When a game developer wants to quickly produce background tiles of multiple resolutions with a centered red marker to align level‑design assets.
 */
