using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output\\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source bound to the output path
        Source source = new FileCreateSource(outputPath, false);

        // BMP options with the source
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        // Define canvas size
        int width = 200;
        int height = 200;

        // Create the BMP canvas (bound image)
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear background to navy
            graphics.Clear(Color.Navy);

            // White pen for the diagonal lines
            Pen whitePen = new Pen(Color.White, 1);

            // Draw two diagonal lines forming a cross
            graphics.DrawLine(whitePen, 0, 0, width, height);
            graphics.DrawLine(whitePen, 0, height, width, 0);

            // Save the bound image
            canvas.Save();
        }
    }
}