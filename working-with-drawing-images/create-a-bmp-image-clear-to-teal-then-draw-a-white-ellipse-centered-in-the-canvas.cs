using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hardcoded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source bound to the output path
        Source source = new FileCreateSource(outputPath, false);

        // Set BMP options with the source
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        // Define canvas size
        int width = 500;
        int height = 500;

        // Create a BMP canvas bound to the file
        using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear the canvas to teal color
            graphics.Clear(Color.FromArgb(255, 0, 128, 128));

            // Create a white pen for the ellipse
            Pen pen = new Pen(Color.White, 2);

            // Define ellipse bounds centered in the canvas (300x300)
            Rectangle ellipseRect = new Rectangle((width - 300) / 2, (height - 300) / 2, 300, 300);

            // Draw the ellipse
            graphics.DrawEllipse(pen, ellipseRect);

            // Save the bound image (file already specified in options)
            canvas.Save();
        }
    }
}