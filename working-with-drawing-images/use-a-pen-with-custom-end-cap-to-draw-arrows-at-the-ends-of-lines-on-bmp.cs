// HOW-TO: Draw Arrow Line on BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "arrow.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions createOptions = new BmpOptions();
            createOptions.Source = new FileCreateSource(outputPath, false);

            int width = 300;
            int height = 300;

            using (Image image = Image.Create(createOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 5);
                pen.EndCap = LineCap.ArrowAnchor;

                graphics.DrawLine(pen, new Point(50, 50), new Point(250, 250));

                image.Save();
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
 * 1. When you need to generate a BMP diagram that shows directional flow, such as a simple flowchart arrow, you can use this code to draw a line with an arrowhead.
 * 2. When creating technical documentation that includes annotated screenshots, the code lets you programmatically add arrow markers to BMP files to highlight features.
 * 3. When building a Windows desktop application that visualizes vector paths, you can render arrows on BMP canvases to indicate start‑to‑end directions.
 * 4. When automating the production of printable schematics in BMP format, the Pen with an ArrowAnchor end cap provides a quick way to illustrate connections between components.
 * 5. When developing a game or simulation that requires overlaying directional cues on bitmap backgrounds, this snippet draws clear arrow lines without needing external graphics editors.
 */
