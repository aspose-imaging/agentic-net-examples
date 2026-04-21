using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw a rectangle
                graphics.DrawRectangle(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                    new Aspose.Imaging.Rectangle(50, 50, 200, 150));

                // Draw an ellipse
                graphics.DrawEllipse(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2),
                    new Aspose.Imaging.Rectangle(300, 100, 100, 100));

                // Draw a line
                graphics.DrawLine(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2),
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(400, 300));

                // Draw a polygon
                graphics.DrawPolygon(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 2),
                    new[] {
                        new Aspose.Imaging.Point(100, 200),
                        new Aspose.Imaging.Point(150, 250),
                        new Aspose.Imaging.Point(200, 200)
                    });

                // Save the modified image as BMP
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}