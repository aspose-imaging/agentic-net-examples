using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.DrawLine(new Pen(Color.Black, 2), new PointF(50f, 50f), new PointF(450f, 450f));
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
 * 1. When a developer needs to generate a blank PNG canvas and programmatically draw a diagonal line for a simple placeholder or watermark in a .NET application.
 * 2. When an automated reporting tool must create a 500×500 pixel image with a black line to illustrate a trend or connection between two points in a PDF or HTML report.
 * 3. When a web service processes user‑uploaded images and must overlay a straight line on a new PNG file to indicate measurement or alignment guides.
 * 4. When a desktop utility has to produce a quick visual cue, such as a separator line, on a white background for UI mockups without relying on external graphics editors.
 * 5. When a batch script needs to validate that the Aspose.Imaging library can create a PNG file, clear the background, and draw a line using C# Graphics and Pen objects for unit testing image rendering pipelines.
 */