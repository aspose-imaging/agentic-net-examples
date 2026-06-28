using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Blue, 2);

                Point pt1 = new Point(50, 250);
                Point pt2 = new Point(150, 50);
                Point pt3 = new Point(250, 450);
                Point pt4 = new Point(350, 250);

                graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                image.Save(outputPath);
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
 * 1. When a developer needs to add a smooth, custom‑shaped blue curve to a PNG logo for branding purposes, they can use Graphics.DrawBezier with Point structures to draw the precise Bézier path.
 * 2. When generating dynamic report graphics where a curved connector line must link data points on a chart saved as a PNG, the code lets the developer define exact control points for the curve.
 * 3. When creating a watermark that follows a specific artistic arc across an image, using Aspose.Imaging’s DrawBezier overload ensures pixel‑perfect placement of the curve on the output file.
 * 4. When building a game UI overlay that requires a high‑resolution curved border around a button in a PNG asset, the developer can specify the four points to render the curve accurately.
 * 5. When automating the conversion of scanned hand‑drawn sketches into vector‑like smooth curves within a PNG, the DrawBezier method with Point coordinates provides the needed precision for the final image.
 */