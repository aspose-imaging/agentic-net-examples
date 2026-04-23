using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output BMP file path
        string outputPath = @"c:\temp\translated_output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source for the BMP image
        Source source = new FileCreateSource(outputPath, false);
        // Set BMP options with the source
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        // Create a BMP canvas of size 400x300 bound to the output file
        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background with light gray color
            graphics.Clear(Color.LightGray);

            // Shift the drawing origin by (50, 30)
            graphics.TranslateTransform(50f, 30f);

            // Create a blue pen with thickness 2
            Pen pen = new Pen(Color.Blue, 2);

            // Draw a rectangle at the new origin (0,0) with size 100x50
            graphics.DrawRectangle(pen, new Rectangle(0, 0, 100, 50));

            // Draw a line from (0,0) to (100,100) using the same pen
            graphics.DrawLine(pen, new Point(0, 0), new Point(100, 100));

            // Save the bound image (output file is already bound via FileCreateSource)
            image.Save();
        }
    }
}