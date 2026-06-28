using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
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
 * 1. When a developer needs to generate a PNG diagram with a simple black line for a report or UI placeholder, they can use Aspose.Imaging for .NET to create a 500×500 image and draw the line with Graphics.DrawLine.
 * 2. When an application must programmatically add a straight line annotation to a blank canvas for a PDF preview or thumbnail, the code shows how to use C# and Aspose.Imaging to render the line and save it as a PNG file.
 * 3. When building a custom charting component that requires drawing axis lines on a raster image, this example demonstrates creating a PNG image, clearing it to white, and drawing a line with a Pen in C#.
 * 4. When automating the creation of watermark or guide lines in a graphics workflow, developers can employ Aspose.Imaging’s Graphics object to draw precise line coordinates and output the result as a PNG.
 * 5. When testing image processing pipelines that need a known simple shape, such as a diagonal line, this code provides a reproducible way to generate a PNG file using Aspose.Imaging for .NET.
 */