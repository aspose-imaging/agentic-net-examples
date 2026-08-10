// HOW-TO: How To Reset Clipping Region After Drawing In Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\clipping_example.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);

                // Set a clipping region
                graphics.Clip = new Region(new Rectangle(50, 50, 300, 300));

                // Draw within the clipping region
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, 0, 400, 400));
                }

                // Reset clipping region to full canvas
                graphics.Clip = null;

                // Draw after resetting the clip
                using (SolidBrush brush2 = new SolidBrush(Color.Red))
                {
                    graphics.FillEllipse(brush2, new Rectangle(100, 100, 200, 200));
                }

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
 * 1. When you need to draw a shape only inside a specific area of a PNG and then continue drawing on the entire image without the previous clipping constraints.
 * 2. When generating dynamic graphics where a background fill must be limited to a rectangle but subsequent overlays like circles should cover the whole canvas.
 * 3. When creating layered illustrations in C# using Aspose.Imaging and you must clear a previously set clipping region before adding additional elements.
 * 4. When producing a PNG report that requires a masked region for one graphic element and then unmasked drawing for later elements.
 * 5. When implementing custom image processing pipelines that need to temporarily restrict drawing operations and then restore full drawing capability.
 */
