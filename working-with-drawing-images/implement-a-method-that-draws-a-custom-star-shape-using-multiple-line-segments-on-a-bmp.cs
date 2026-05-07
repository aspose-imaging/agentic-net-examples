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
            // Output BMP file path
            string outputPath = @"C:\temp\star.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define image dimensions
            int width = 500;
            int height = 500;

            // Create the image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Pen for drawing the star
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);

                // Define star points (outer and inner vertices)
                Aspose.Imaging.Point[] starPoints = new Aspose.Imaging.Point[]
                {
                    new Aspose.Imaging.Point(250, 50),   // top
                    new Aspose.Imaging.Point(300, 200),
                    new Aspose.Imaging.Point(450, 200),
                    new Aspose.Imaging.Point(325, 300),
                    new Aspose.Imaging.Point(375, 450),
                    new Aspose.Imaging.Point(250, 350),
                    new Aspose.Imaging.Point(125, 450),
                    new Aspose.Imaging.Point(175, 300),
                    new Aspose.Imaging.Point(50, 200),
                    new Aspose.Imaging.Point(200, 200)
                };

                // Draw lines between consecutive points and close the shape
                for (int i = 0; i < starPoints.Length; i++)
                {
                    Aspose.Imaging.Point start = starPoints[i];
                    Aspose.Imaging.Point end = starPoints[(i + 1) % starPoints.Length];
                    graphics.DrawLine(pen, start, end);
                }

                // Save the image (file is already bound to the output path)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}