using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = @"C:\temp\bezier_output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set PNG options with the stream source
                var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions();
                pngOptions.Source = new Aspose.Imaging.Sources.StreamSource(stream);

                // Create a new image canvas
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
                {
                    // Initialize graphics for drawing
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Define a pen for the Bezier curve
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);

                    // Draw a Bezier curve using Point structures
                    graphics.DrawBezier(pen,
                        new Aspose.Imaging.Point(50, 250),
                        new Aspose.Imaging.Point(150, 50),
                        new Aspose.Imaging.Point(350, 450),
                        new Aspose.Imaging.Point(450, 250));

                    // Save the image (stream is already bound)
                    image.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}