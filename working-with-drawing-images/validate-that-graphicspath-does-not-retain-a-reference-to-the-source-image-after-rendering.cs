using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath1 = "output1.png";
            string outputPath2 = "output2.png";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2) ?? ".");

            // Load source image to obtain dimensions
            int width, height;
            using (Aspose.Imaging.Image srcImage = Aspose.Imaging.Image.Load(inputPath))
            {
                width = srcImage.Width;
                height = srcImage.Height;
            }

            // Create a GraphicsPath with a simple rectangle shape
            var graphicsPath = new Aspose.Imaging.GraphicsPath();
            var figure = new Aspose.Imaging.Figure();
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(10f, 10f, 200f, 200f)));
            graphicsPath.AddFigure(figure);

            // Draw the path onto the first new image
            var pngOptions1 = new PngOptions();
            pngOptions1.Source = new FileCreateSource(outputPath1, false);
            using (Aspose.Imaging.Image img1 = Aspose.Imaging.Image.Create(pngOptions1, width, height))
            {
                var graphics = new Aspose.Imaging.Graphics(img1);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicsPath);
                img1.Save();
            }

            // Reuse the same GraphicsPath on a second image to verify no retained reference to the first image
            var pngOptions2 = new PngOptions();
            pngOptions2.Source = new FileCreateSource(outputPath2, false);
            using (Aspose.Imaging.Image img2 = Aspose.Imaging.Image.Create(pngOptions2, width, height))
            {
                var graphics = new Aspose.Imaging.Graphics(img2);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2), graphicsPath);
                img2.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}