// HOW-TO: Fill Entire PNG Image with Red Color Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillRectangle(brush, new Aspose.Imaging.RectangleF(0, 0, image.Width, image.Height));
                }

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to generate a solid‑color placeholder PNG for UI mockups or testing.
 * 2. When you want to replace an existing image’s background with a uniform red overlay before adding other graphics.
 * 3. When creating a red background layer for a composite image that will later have transparent elements drawn on top.
 * 4. When programmatically resetting a PNG’s pixels to a known color as part of a batch‑processing cleanup routine.
 * 5. When producing a simple red badge or icon without loading external assets, using only Aspose.Imaging in C#.
 */
