using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\hatch.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (BmpImage canvas = (BmpImage)Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.Ivory);
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1f);

                for (int offset = 0; offset < width; offset += 20)
                {
                    graphics.DrawLine(pen, offset, 0, width, height - offset);
                    graphics.DrawLine(pen, 0, offset, width - offset, height);
                }

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
 * 1. When a developer needs to generate a 24‑bit BMP file as a background texture for a Windows desktop application, they can use this code to create an ivory canvas with a black diagonal hatch pattern.
 * 2. When an automated reporting tool must embed a simple patterned image (e.g., a hatch overlay) into PDF or Word documents, the code can programmatically produce the BMP that can be inserted later.
 * 3. When a game engine requires a tiled bitmap for a floor or wall surface, this snippet shows how to create a BMP with a repeatable diagonal line hatch that can be saved and reused.
 * 4. When a batch image‑processing pipeline needs to create placeholder images for testing image‑compression algorithms, the code quickly generates a BMP with known geometry and color.
 * 5. When a developer is building a custom printer driver that expects a BMP raster image with a specific hatch pattern for calibration, this example demonstrates how to produce the required file using C# and Aspose.Imaging.
 */