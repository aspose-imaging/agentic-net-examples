using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var raster = (Aspose.Imaging.RasterImage)image;

                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(raster);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawRectangle(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                    new Aspose.Imaging.Rectangle(50, 50, 200, 150));
                graphics.DrawEllipse(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2),
                    new Aspose.Imaging.Rectangle(100, 100, 150, 100));

                raster.Save(outputPath);
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
 * 1. When a developer needs to generate a white‑background BMP template and overlay simple vector shapes such as rectangles and ellipses for a quick mock‑up of a UI component.
 * 2. When an automated reporting tool must take an existing BMP scan, erase its contents with a white fill, and annotate it with geometric markers to highlight regions of interest.
 * 3. When a batch‑processing script has to prepare BMP assets for a game by clearing previous drawings and adding new shape outlines for collision boundaries.
 * 4. When a legacy system that only accepts BMP files requires programmatic creation of a clean canvas with overlaid shapes for printing engineering diagrams.
 * 5. When a C# application needs to programmatically reset a BMP image, draw measurement guides, and save the result for downstream image‑analysis pipelines.
 */