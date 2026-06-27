using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.psd";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PsdOptions options = new PsdOptions();
            options.ColorMode = ColorModes.Indexed;
            options.Palette = new ColorPalette(new Color[] { Color.Black, Color.White });
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 10), new Point(190, 190));
                image.Save();
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
 * 1. When a developer needs to use Aspose.Imaging for .NET to generate an indexed‑color PSD file with a black diagonal line as a thumbnail preview in a design workflow.
 * 2. When an application must programmatically create a 200 × 200 PSD canvas with a limited palette and draw a line using the Graphics object to illustrate vector guides for a printing pipeline.
 * 3. When a graphics tool wants to export a simple indexed PSD containing a diagonal line for inclusion in a sprite sheet or game asset using C# and Aspose.Imaging.
 * 4. When an automated report generator has to embed a basic line diagram into an indexed PSD that will later be edited in Photoshop, leveraging the DrawLine method.
 * 5. When a batch process creates placeholder PSD files with a black line to test color mode handling, palette support, and Graphics rendering in an image‑processing pipeline.
 */