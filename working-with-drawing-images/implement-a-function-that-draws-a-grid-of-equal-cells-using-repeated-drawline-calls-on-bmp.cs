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
            // Output BMP file path (hard‑coded)
            string outputPath = @"C:\temp\grid.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Canvas size and cell size
            int width = 800;
            int height = 600;
            int cellSize = 50; // equal square cells

            // Configure BMP options with a file create source (output is bound)
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Pen for grid lines
                Pen pen = new Pen(Color.Black, 1);

                // Draw vertical grid lines
                for (int x = 0; x <= width; x += cellSize)
                {
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                // Draw horizontal grid lines
                for (int y = 0; y <= height; y += cellSize)
                {
                    graphics.DrawLine(pen, 0, y, width, y);
                }

                // Save the image (already bound to the output file)
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
 * 1. When a developer needs to generate a printable BMP worksheet with a uniform grid using Aspose.Imaging’s Graphics.DrawLine and Pen objects for manual data entry or graph paper.
 * 2. When a game developer wants to create a tiled background BMP image by drawing equal‑sized cells with repeated DrawLine calls for a 2‑D puzzle or board game.
 * 3. When a reporting tool must overlay a grid onto a BMP chart using C# Graphics and Pen to align plotted points with a fixed cell size.
 * 4. When a CAD or mapping application requires a simple raster reference grid in BMP, produced with Aspose.Imaging’s DrawLine loop, to help users measure distances.
 * 5. When an automation script has to produce a BMP template with evenly spaced cells for subsequent image analysis or OCR preprocessing.
 */