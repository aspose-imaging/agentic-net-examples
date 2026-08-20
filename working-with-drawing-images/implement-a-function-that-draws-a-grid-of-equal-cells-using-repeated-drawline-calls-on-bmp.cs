// HOW-TO: Create a BMP Grid Image With Equal Cells Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\grid.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int canvasWidth = 800;
            int canvasHeight = 600;
            int cellSize = 50;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, canvasWidth, canvasHeight))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 1);

                for (int x = 0; x <= canvasWidth; x += cellSize)
                {
                    graphics.DrawLine(pen, x, 0, x, canvasHeight);
                }

                for (int y = 0; y <= canvasHeight; y += cellSize)
                {
                    graphics.DrawLine(pen, 0, y, canvasWidth, y);
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
 * 1. When you need to generate a printable graph paper background as a BMP for a drawing application.
 * 2. When you want to create a tiled game board image for a 2‑D board game prototype in C#.
 * 3. When you must produce a layout reference image for UI mock‑ups that requires evenly spaced grid lines.
 * 4. When you need to export a simple spreadsheet‑style cell diagram to BMP for documentation or reporting.
 * 5. When you are building a custom image processing pipeline that requires a baseline grid overlay for alignment testing.
 */
