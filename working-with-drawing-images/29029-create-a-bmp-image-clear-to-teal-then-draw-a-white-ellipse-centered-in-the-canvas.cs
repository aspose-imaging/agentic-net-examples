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
        string outputPath = @"c:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source for the BMP image
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = source;

        // Create a 500x500 BMP canvas
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear canvas to teal color
            graphics.Clear(Color.Teal);

            // Prepare a white pen for the ellipse
            Pen pen = new Pen(Color.White, 2);

            // Calculate centered ellipse bounds
            int canvasWidth = image.Width;
            int canvasHeight = image.Height;
            int ellipseWidth = canvasWidth / 2;
            int ellipseHeight = canvasHeight / 2;
            int x = (canvasWidth - ellipseWidth) / 2;
            int y = (canvasHeight - ellipseHeight) / 2;

            // Draw the centered white ellipse
            graphics.DrawEllipse(pen, x, y, ellipseWidth, ellipseHeight);

            // Save the image (bound to the file source)
            image.Save();
        }
    }
}