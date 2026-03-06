using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Create a PNG image of 200x200 pixels
        using (PngImage png = new PngImage(200, 200))
        {
            // Draw on the image
            Graphics graphics = new Graphics(png);
            SolidBrush brush = new SolidBrush(Color.Red);
            graphics.FillRectangle(brush, png.Bounds);

            // Save the PNG image
            png.Save(outputPath);
        }
    }
}