using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a bound source for the BMP image
        FileCreateSource source = new FileCreateSource(outputPath, false);
        BmpOptions options = new BmpOptions() { Source = source };

        // Canvas size
        int width = 500;
        int height = 500;

        // Create the BMP canvas (bound to the file)
        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(options, width, height))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);

            // Thick red pen (e.g., 10 pixels)
            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 10);

            // Draw rectangle border around the entire canvas
            graphics.DrawRectangle(pen, 0, 0, width, height);

            // Save the bound image
            canvas.Save();
        }
    }
}