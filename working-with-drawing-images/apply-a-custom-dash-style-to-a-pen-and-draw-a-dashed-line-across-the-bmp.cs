using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path (hardcoded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Define canvas size
        int width = 800;
        int height = 600;

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a pen with custom dash style
            Pen pen = new Pen(Color.Black, 5f);
            pen.DashStyle = DashStyle.Custom;
            pen.DashPattern = new float[] { 10f, 5f }; // dash length 10, space length 5

            // Draw a horizontal dashed line across the image
            graphics.DrawLine(pen, 0, height / 2, width, height / 2);

            // Save the image (output path already bound via FileCreateSource)
            image.Save();
        }
    }
}