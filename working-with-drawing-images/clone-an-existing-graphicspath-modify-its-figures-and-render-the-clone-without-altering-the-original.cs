using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path (not used further, but required by safety rules)
        string inputPath = "input.png";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Output paths for original and cloned graphics paths
        string outputPathOriginal = "original.png";
        string outputPathClone = "clone.png";

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathOriginal));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathClone));

        // Create an original GraphicsPath with a rectangle figure
        GraphicsPath originalPath = new GraphicsPath();
        Figure rectFigure = new Figure();
        rectFigure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 200f, 200f)));
        originalPath.AddFigure(rectFigure);

        // Deep clone the original path
        GraphicsPath clonedPath = originalPath.DeepClone();

        // Modify the cloned path by adding an ellipse figure
        Figure ellipseFigure = new Figure();
        ellipseFigure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 150f, 150f)));
        clonedPath.AddFigure(ellipseFigure);

        // Render the original path to an image
        PngOptions pngOptionsOriginal = new PngOptions();
        pngOptionsOriginal.Source = new FileCreateSource(outputPathOriginal, false);
        using (Image imageOriginal = Image.Create(pngOptionsOriginal, 300, 300))
        {
            Graphics graphics = new Graphics(imageOriginal);
            graphics.Clear(Color.White);
            graphics.DrawPath(new Pen(Color.Black, 2), originalPath);
            imageOriginal.Save(); // Save bound to the FileCreateSource
        }

        // Render the cloned (modified) path to a separate image
        PngOptions pngOptionsClone = new PngOptions();
        pngOptionsClone.Source = new FileCreateSource(outputPathClone, false);
        using (Image imageClone = Image.Create(pngOptionsClone, 300, 300))
        {
            Graphics graphics = new Graphics(imageClone);
            graphics.Clear(Color.White);
            graphics.DrawPath(new Pen(Color.Black, 2), clonedPath);
            imageClone.Save(); // Save bound to the FileCreateSource
        }
    }
}