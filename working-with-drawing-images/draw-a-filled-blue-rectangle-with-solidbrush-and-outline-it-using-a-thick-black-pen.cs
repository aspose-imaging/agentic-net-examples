using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\rectangle.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a PNG image with desired dimensions
        PngOptions pngOptions = new PngOptions();
        using (Image image = Image.Create(pngOptions, 300, 200))
        {
            // Initialize graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Define a solid blue brush and fill the rectangle
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            graphics.FillRectangle(blueBrush, new Rectangle(20, 20, 260, 160));

            // Define a thick black pen and draw the rectangle outline
            Pen blackPen = new Pen(Color.Black, 5);
            graphics.DrawRectangle(blackPen, new Rectangle(20, 20, 260, 160));

            // Save the image to the specified path
            image.Save(outputPath);
        }
    }
}