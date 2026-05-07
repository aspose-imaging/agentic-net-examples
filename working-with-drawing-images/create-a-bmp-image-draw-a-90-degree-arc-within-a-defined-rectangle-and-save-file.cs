using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\arc_output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Create a BMP canvas of size 300x300
            using (Image canvas = Image.Create(bmpOptions, 300, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Draw a 90-degree arc within the defined rectangle
                graphics.DrawArc(new Pen(Color.Black, 2), new Rectangle(50, 50, 200, 200), 0, 90);

                // Save the bound image
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}