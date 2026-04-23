using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));

        // Load the source image (used only for dimensions)
        using (Aspose.Imaging.Image srcImage = Aspose.Imaging.Image.Load(inputPath))
        {
            // Create a GraphicsPath with some shapes
            Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(10f, 10f, 200f, 200f)));
            figure.AddShape(new Aspose.Imaging.Shapes.EllipseShape(new Aspose.Imaging.RectangleF(50f, 50f, 150f, 150f)));
            path.AddFigure(figure);

            // First output image: draw the path with a black pen
            using (Aspose.Imaging.Image img1 = Aspose.Imaging.Image.Create(new PngOptions(), srcImage.Width, srcImage.Height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(img1);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), path);
                img1.Save(outputPath1);
            }

            // Second output image: draw the same path with a blue pen
            using (Aspose.Imaging.Image img2 = Aspose.Imaging.Image.Create(new PngOptions(), srcImage.Width, srcImage.Height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(img2);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2), path);
                img2.Save(outputPath2);
            }
        }
    }
}