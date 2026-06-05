using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 600, 600))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Orange, 2);
                graphics.DrawLine(pen, 0, 0, 600, 600);
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
 * 1. When a developer needs to generate a simple diagnostic image, such as a 600 × 600 BMP with a diagonal orange line, to verify that the Aspose.Imaging Graphics.DrawLine overload works correctly.
 * 2. When creating a placeholder thumbnail for a document management system, and the placeholder must be a BMP file with a visible orange diagonal marker to indicate missing content.
 * 3. When building a test suite for image‑processing pipelines that requires a known BMP image with a specific line geometry to validate scaling or rotation algorithms.
 * 4. When producing a quick visual cue for a UI mock‑up, such as an orange diagonal line across a 600 × 600 bitmap that can be overlaid on other graphics during prototyping.
 * 5. When automating the generation of simple graphics for educational tutorials that demonstrate C# file I/O, Aspose.Imaging BmpOptions, and the use of Pen objects to draw lines.
 */