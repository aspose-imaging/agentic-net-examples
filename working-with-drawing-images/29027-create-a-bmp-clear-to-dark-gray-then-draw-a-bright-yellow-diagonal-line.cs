using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hardcoded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output BMP image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up BMP options with the stream as the source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(stream);

            // Create a new image with the specified dimensions
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing on the image
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear the canvas to dark gray
                graphics.Clear(Aspose.Imaging.Color.DarkGray);

                // Draw a bright yellow diagonal line from top-left to bottom-right
                graphics.DrawLine(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Yellow, 5),
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(499, 499));

                // Save the changes to the image (stream is already bound)
                image.Save();
            }
        }
    }
}