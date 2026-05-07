using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            int width = 500;
            int height = 500;

            using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.DarkGray);
                graphics.DrawLine(new Pen(Color.Yellow, 1), new Point(0, 0), new Point(width, height));
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}