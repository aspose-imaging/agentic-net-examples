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
            string outputPath = @"C:\temp\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 300, 300))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                Aspose.Imaging.Pen blackPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 10);
                graphics.DrawLine(blackPen, 50, 50, 250, 250);

                Aspose.Imaging.Pen whitePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.White, 2);
                graphics.DrawLine(whitePen, 50, 50, 250, 250);

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
 * 1. When a developer needs to generate a BMP thumbnail with a highlighted diagonal line for a document preview.
 * 2. When a C# application must create a simple vector‑based watermark by drawing a thick black line with a white outline on a bitmap.
 * 3. When an image processing service has to produce a high‑contrast guide line for calibrating scanning equipment using Aspose.Imaging.
 * 4. When a game UI requires a static BMP asset that shows a bold line with a contrasting edge for a level‑map overlay.
 * 5. When a reporting tool needs to embed a BMP diagram with a double‑stroked line to emphasize a trend line in generated PDFs.
 */