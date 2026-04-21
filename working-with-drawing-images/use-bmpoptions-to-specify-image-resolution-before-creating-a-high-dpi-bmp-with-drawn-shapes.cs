using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\highdpi_output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with high DPI resolution
        BmpOptions options = new BmpOptions();
        options.BitsPerPixel = 24;
        options.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300.0, 300.0);
        options.Source = new FileCreateSource(outputPath, false);

        // Desired canvas size
        int width = 800;
        int height = 600;

        // Create the BMP image with the specified options
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, width, height))
        {
            // Obtain a Graphics object for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Clear background to white
            graphics.Clear(Aspose.Imaging.Color.White);

            // Draw a blue line and rectangle using a Pen
            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);
            graphics.DrawLine(pen, new Aspose.Imaging.Point(100, 100), new Aspose.Imaging.Point(700, 100));
            graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(150, 150, 200, 100));

            // Fill an ellipse with a solid red brush
            using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
            {
                graphics.FillEllipse(brush, new Aspose.Imaging.Rectangle(400, 300, 150, 100));
            }

            // Save the image (the output path is already bound via the source)
            image.Save();
        }
    }
}