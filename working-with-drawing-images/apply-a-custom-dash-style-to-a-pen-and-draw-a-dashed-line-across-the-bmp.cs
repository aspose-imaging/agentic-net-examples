using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output BMP path
        string outputPath = @"C:\Temp\DashedLine.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Image image = Image.Create(bmpOptions, 800, 200))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a pen with custom dash style
            Pen pen = new Pen(Color.Black, 5f);
            pen.DashStyle = DashStyle.Custom;
            pen.DashPattern = new float[] { 10f, 5f, 2f, 5f }; // dash, space, dash, space

            // Draw a horizontal dashed line across the image
            graphics.DrawLine(pen, 0, image.Height / 2, image.Width, image.Height / 2);

            // Save the image (output path already bound)
            image.Save();
        }
    }
}