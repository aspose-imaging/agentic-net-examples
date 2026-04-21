using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"C:\Temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a source bound to the output file
        FileCreateSource source = new FileCreateSource(outputPath, false);

        // Set BMP options with the source
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        // Create a BMP canvas
        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(bmpOptions, 400, 400))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);

            // Clear background
            graphics.Clear(Aspose.Imaging.Color.White);

            // Draw a 90-degree arc within the defined rectangle
            graphics.DrawArc(
                new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                new Aspose.Imaging.Rectangle(50, 50, 300, 300),
                0,
                90);

            // Save the image (bound to the source)
            canvas.Save();
        }
    }
}