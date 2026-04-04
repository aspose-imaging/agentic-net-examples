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
        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source bound to the output path
        Source source = new FileCreateSource(outputPath, false);

        // Set BMP options with the source
        BmpOptions options = new BmpOptions() { Source = source };

        // Define canvas size
        int width = 500;
        int height = 500;

        // Create a BMP canvas bound to the file
        using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear the canvas to navy
            graphics.Clear(Color.Navy);

            // White pen for the cross
            Pen whitePen = new Pen(Color.White, 5);

            // Diagonal from top‑left to bottom‑right
            graphics.DrawLine(whitePen, new Point(0, 0), new Point(width, height));

            // Diagonal from bottom‑left to top‑right
            graphics.DrawLine(whitePen, new Point(0, height), new Point(width, 0));

            // Save the bound image
            canvas.Save();
        }
    }
}