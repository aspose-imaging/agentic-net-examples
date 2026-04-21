using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = @"C:\temp\ellipse.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 image canvas
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Fill background with a light gray color
            graphics.Clear(Color.LightGray);

            // Create a pen with custom dash pattern
            Pen pen = new Pen(Color.Blue, 3);
            pen.DashPattern = new float[] { 5, 2 }; // dash length 5, gap 2

            // Draw an ellipse using the custom pen
            graphics.DrawEllipse(pen, new Rectangle(100, 100, 300, 200));

            // Save the image (output is already bound to the file)
            image.Save();
        }
    }
}