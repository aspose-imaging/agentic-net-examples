using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create BMP canvas
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            using (Image canvas = Image.Create(bmpOptions, 500, 500))
            {
                // Clear to teal
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.Teal);

                // Draw white ellipse centered
                Pen pen = new Pen(Color.White, 2);
                RectangleF ellipseRect = new RectangleF(50, 50, 400, 400);
                graphics.DrawEllipse(pen, ellipseRect);

                // Save bound image
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}