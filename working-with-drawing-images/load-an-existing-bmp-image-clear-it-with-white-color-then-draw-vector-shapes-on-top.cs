using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw a blue rectangle
                graphics.DrawRectangle(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3),
                    new Aspose.Imaging.Rectangle(50, 50, 200, 150));

                // Draw a red ellipse
                graphics.DrawEllipse(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2),
                    new Aspose.Imaging.Rectangle(300, 100, 100, 100));

                // Draw a green diagonal line
                graphics.DrawLine(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 4),
                    new Aspose.Imaging.Point(0, 0),
                    new Aspose.Imaging.Point(400, 300));

                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}