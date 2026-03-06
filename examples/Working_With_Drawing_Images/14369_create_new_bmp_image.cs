using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Path where the BMP image will be saved
        string outputPath = "output.bmp";

        // Create a new BMP image with the desired width and height
        using (BmpImage bmpImage = new BmpImage(200, 200))
        {
            // Obtain a graphics object for drawing on the image
            Graphics graphics = new Graphics(bmpImage);

            // Fill the entire image with a solid blue color
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            graphics.FillRectangle(blueBrush, bmpImage.Bounds);

            // Save the BMP image to the specified file
            bmpImage.Save(outputPath);
        }
    }
}