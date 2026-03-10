using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with desired dimensions
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define a black pen with thickness 2
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);

                // Draw rectangle border
                graphics.DrawLine(pen, new Aspose.Imaging.Point(10, 10), new Aspose.Imaging.Point(390, 10));
                graphics.DrawLine(pen, new Aspose.Imaging.Point(390, 10), new Aspose.Imaging.Point(390, 290));
                graphics.DrawLine(pen, new Aspose.Imaging.Point(390, 290), new Aspose.Imaging.Point(10, 290));
                graphics.DrawLine(pen, new Aspose.Imaging.Point(10, 290), new Aspose.Imaging.Point(10, 10));

                // Draw diagonal lines
                graphics.DrawLine(pen, new Aspose.Imaging.Point(10, 10), new Aspose.Imaging.Point(390, 290));
                graphics.DrawLine(pen, new Aspose.Imaging.Point(390, 10), new Aspose.Imaging.Point(10, 290));

                // Save the image
                image.Save();
            }
        }
    }
}