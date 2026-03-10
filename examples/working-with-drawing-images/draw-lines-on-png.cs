using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class DrawLinesOnPng
{
    static void Main()
    {
        // Path where the PNG will be saved
        string outputPath = @"C:\temp\lines.png";

        // Create a FileStream for the output file
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Initialize PNG options and set the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 400x400 PNG image
            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                // Initialize Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background with a light color
                graphics.Clear(Color.LightGray);

                // Draw several lines with different colors and thicknesses
                // Red line from (50,50) to (350,50)
                graphics.DrawLine(new Pen(Color.Red, 3), new Point(50, 50), new Point(350, 50));

                // Green diagonal line from (50,100) to (350,300)
                graphics.DrawLine(new Pen(Color.Green, 2), new Point(50, 100), new Point(350, 300));

                // Blue line using coordinate overload from (50,350) to (350,350)
                graphics.DrawLine(new Pen(Color.Blue, 4), 50, 350, 350, 350);

                // Save the image (the stream is already linked via pngOptions)
                image.Save();
            }
        }

        Console.WriteLine("PNG image with lines created at: " + outputPath);
    }
}