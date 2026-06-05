using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            FileCreateSource source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            using (BmpImage canvas = (BmpImage)Aspose.Imaging.Image.Create(options, 500, 500))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.Navy);

                Aspose.Imaging.Pen whitePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.White, 2);
                graphics.DrawLine(whitePen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(canvas.Width, canvas.Height));
                graphics.DrawLine(whitePen, new Aspose.Imaging.Point(0, canvas.Height), new Aspose.Imaging.Point(canvas.Width, 0));

                canvas.Save();
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
 * 1. When a developer needs to generate a BMP thumbnail with a navy background and a white diagonal cross as a placeholder image for missing assets.
 * 2. When an application must create a simple 500x500 bitmap logo in C# using Aspose.Imaging to embed a custom cross‑mark watermark.
 * 3. When a reporting tool requires programmatically drawing a high‑contrast navigation symbol on a BMP file for printed manuals.
 * 4. When a game engine needs to produce a solid‑color BMP texture with a white X for debugging collision boundaries.
 * 5. When an automated testing suite must generate a BMP image with known pixel colors to verify image processing pipelines in .NET.
 */