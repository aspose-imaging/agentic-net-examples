using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = @"c:\temp\line_figure.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        var pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 400, 200))
        {
            // Initialize graphics for drawing
            var graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Draw a straight line (start: 50,50; end: 350,150)
            var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
            graphics.DrawLine(pen, 50, 50, 350, 150);

            // Save the image
            image.Save();
        }
    }
}