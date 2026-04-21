using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"C:\temp\arrows.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options and bind to the output file
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 400x400 BMP image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 400))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Create a pen with arrow caps at both ends
            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 5f);
            pen.StartCap = Aspose.Imaging.LineCap.ArrowAnchor;
            pen.EndCap = Aspose.Imaging.LineCap.ArrowAnchor;

            // Draw lines with arrowheads
            graphics.DrawLine(pen, 50, 50, 350, 50);
            graphics.DrawLine(pen, 50, 100, 350, 200);
            graphics.DrawLine(pen, 50, 150, 350, 350);

            // Save the image (already bound to outputPath)
            image.Save();
        }
    }
}