using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 600, 600))
            {
                Graphics graphics = new Graphics(image);
                graphics.DrawLine(new Pen(Color.Orange, 2), 0, 0, 600, 600);
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
 * 1. When a developer needs to generate a simple 600 × 600 BMP placeholder image with a visible diagonal orange line for UI mock‑ups or testing image loading pipelines.
 * 2. When an automated test suite must create a BMP file on the fly and draw a diagonal orange line to verify that Aspose.Imaging’s Graphics.DrawLine overload correctly renders vector graphics.
 * 3. When a reporting tool requires a quick way to add a colored diagonal marker to a BMP chart background to highlight trends without using external design software.
 * 4. When a game asset pipeline needs to programmatically produce a 600 × 600 BMP texture with an orange diagonal line for debugging collision boundaries.
 * 5. When a documentation generator wants to embed a sample BMP image showing the effect of the Pen(Color.Orange, 2) parameter in C# image processing tutorials.
 */