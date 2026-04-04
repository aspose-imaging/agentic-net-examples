using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\arrow.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options with a file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 BMP image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a pen with custom end cap (arrow)
            Pen pen = new Pen(Color.Blue, 5f);
            pen.EndCap = LineCap.ArrowAnchor; // Arrow at the end of the line
            pen.StartCap = LineCap.Flat;      // Flat start cap (optional)

            // Draw a horizontal line with an arrow at the end
            graphics.DrawLine(pen, new Point(50, 250), new Point(450, 250));

            // Save the image (output file is already bound to the source)
            image.Save();
        }
    }
}