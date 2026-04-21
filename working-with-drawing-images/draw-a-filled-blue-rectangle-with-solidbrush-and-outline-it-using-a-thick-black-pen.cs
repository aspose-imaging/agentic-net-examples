using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\filled_rectangle.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a PNG image of size 400x300
        PngOptions pngOptions = new PngOptions();
        using (Image image = Image.Create(pngOptions, 400, 300))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Define rectangle dimensions
            int rectX = 50;
            int rectY = 50;
            int rectWidth = 300;
            int rectHeight = 200;

            // Fill the rectangle with blue color
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            graphics.FillRectangle(blueBrush, rectX, rectY, rectWidth, rectHeight);

            // Outline the rectangle with a thick black pen (5 pixels)
            Pen blackPen = new Pen(Color.Black, 5);
            graphics.DrawRectangle(blackPen, rectX, rectY, rectWidth, rectHeight);

            // Save the image to the specified path
            image.Save(outputPath);
        }
    }
}