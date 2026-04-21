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
        string outputPath = @"C:\Temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 200x200 BMP image
        using (Image image = Image.Create(bmpOptions, 200, 200))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Create a black pen
            Pen pen = new Pen(Color.Black, 2);

            // Draw a line
            graphics.DrawLine(pen, new Point(20, 20), new Point(180, 20));

            // Apply scaling to double the size
            graphics.ScaleTransform(2.0f, 2.0f);

            // Draw another line (will appear twice as long due to scaling)
            graphics.DrawLine(pen, new Point(20, 40), new Point(180, 40));

            // Save the image (output path is already bound)
            image.Save();
        }
    }
}