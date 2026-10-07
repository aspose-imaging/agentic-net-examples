// HOW-TO: Draw a Black Line on an Indexed PSD Image with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var createOptions = new PsdOptions();
            createOptions.Source = new FileCreateSource(outputPath, false);
            createOptions.ColorMode = ColorModes.Indexed;

            Aspose.Imaging.Color[] palette = new Aspose.Imaging.Color[256];
            for (int i = 0; i < 256; i++)
            {
                palette[i] = Color.FromArgb(255, i, i, i);
            }
            createOptions.Palette = new ColorPalette(palette);

            int width = 200;
            int height = 200;

            using (var image = Image.Create(createOptions, width, height))
            {
                var graphics = new Graphics(image);
                var pen = new Pen(Color.Black, 1);
                graphics.DrawLine(pen, new Point(10, 10), new Point(190, 190));
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
 * 1. When you need to generate a simple indexed‑color PSD thumbnail with a diagonal line for a design preview in a C# application.
 * 2. When you want to programmatically add guide lines to a PSD file before sending it to Photoshop for further editing.
 * 3. When creating batch‑processed PSD assets with a custom grayscale palette for a printing workflow that requires precise line markings.
 * 4. When building a server‑side service that produces PSD files with vector‑like lines without using Photoshop, using Aspose.Imaging for .NET.
 * 5. When testing graphics rendering pipelines by drawing basic shapes on an indexed PSD canvas to verify color palette handling.
 */
