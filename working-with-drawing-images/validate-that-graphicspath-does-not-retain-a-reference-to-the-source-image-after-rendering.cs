// HOW-TO: Check If GraphicsPath Keeps Source Image Reference After Disposal In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath1 = "output1.png";
            string outputPath2 = "output2.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2) ?? ".");

            // Load a source image (only to demonstrate that the path does not keep a reference to it)
            Aspose.Imaging.GraphicsPath path;
            using (Aspose.Imaging.Image srcImage = Aspose.Imaging.Image.Load(inputPath))
            {
                // Create a simple rectangle shape and add it to a figure
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 200f)));

                // Create a GraphicsPath and add the figure
                path = new Aspose.Imaging.GraphicsPath();
                path.AddFigure(figure);
            } // srcImage is disposed here

            // First canvas: draw the path while the source image was still alive
            PngOptions pngOptions1 = new PngOptions();
            pngOptions1.Source = new FileCreateSource(outputPath1, false);
            using (Aspose.Imaging.Image canvas1 = Aspose.Imaging.Image.Create(pngOptions1, 300, 300))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas1);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3), path);
                canvas1.Save(); // bound to file source
            }

            // Second canvas: reuse the same GraphicsPath after the source image has been disposed
            PngOptions pngOptions2 = new PngOptions();
            pngOptions2.Source = new FileCreateSource(outputPath2, false);
            using (Aspose.Imaging.Image canvas2 = Aspose.Imaging.Image.Create(pngOptions2, 300, 300))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas2);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3), path);
                canvas2.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reuse a GraphicsPath after the original PNG image has been disposed to avoid memory leaks in a C# Aspose.Imaging workflow.
 * 2. When generating multiple PNG canvases from shapes extracted from a source image without keeping the source file loaded in memory.
 * 3. When verifying that disposing an Image object does not corrupt subsequent DrawPath calls in an Aspose.Imaging graphics pipeline.
 * 4. When building a server‑side thumbnail service that creates vector overlays from a source image and must release the source file promptly.
 * 5. When debugging errors caused by hidden references to a closed image while drawing vector figures with Aspose.Imaging in .NET.
 */
