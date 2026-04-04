using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hardcoded)
        string outputPath = "output\\result.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a bound file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Define canvas size
        int width = 400;
        int height = 300;

        // Create the image canvas bound to the output file
        using (Image canvas = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Line coordinates
            int x1 = 50, y1 = 50, x2 = 350, y2 = 250;

            // Draw a thick black line
            Pen blackPen = new Pen(Color.Black, 10);
            graphics.DrawLine(blackPen, x1, y1, x2, y2);

            // Overlay a thinner white line for outline effect
            Pen whitePen = new Pen(Color.White, 4);
            graphics.DrawLine(whitePen, x1, y1, x2, y2);

            // Save the bound image
            canvas.Save();
        }
    }
}