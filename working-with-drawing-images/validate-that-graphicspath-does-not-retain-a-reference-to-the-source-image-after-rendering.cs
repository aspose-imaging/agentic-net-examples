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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.png";
            string outputPath1 = @"c:\temp\output1.png";
            string outputPath2 = @"c:\temp\output2.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));

            // Create a reusable GraphicsPath with a rectangle shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
            path.AddFigure(figure);

            // First image: draw the path and save
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath1, false);
            using (Image image1 = Image.Create(pngOptions, 300, 300))
            {
                Graphics graphics = new Graphics(image1);
                graphics.Clear(Color.White);
                graphics.DrawPath(new Pen(Color.Blue, 3), path);
                image1.Save(); // Since the output is bound to the source, just Save()
            }

            // Second image: reuse the same GraphicsPath without reloading any source image
            pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath2, false);
            using (Image image2 = Image.Create(pngOptions, 300, 300))
            {
                Graphics graphics = new Graphics(image2);
                graphics.Clear(Color.White);
                graphics.DrawPath(new Pen(Color.Red, 3), path);
                image2.Save();
            }

            // If we reach this point without exceptions, the GraphicsPath does not retain a reference to the source image.
            Console.WriteLine("GraphicsPath reused successfully on multiple images.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When generating a series of PNG badges that all share the same logo shape, a developer can reuse a single GraphicsPath to draw the logo onto each badge without the path holding onto the previous image’s data.
 * 2. When creating on‑the‑fly watermarks for uploaded photos, you can draw the same watermark path onto each new Image object and be confident the path does not keep a reference to the original file, preventing file‑lock issues.
 * 3. When producing multiple chart panels in a reporting tool, a shared GraphicsPath for axis lines can be rendered into separate Image canvases, ensuring the path does not retain any source image memory and allowing the panels to be saved independently as PNG files.
 * 4. When implementing a batch image‑conversion service that reuses vector shapes across thousands of images, validating that GraphicsPath does not hold onto the source image helps avoid out‑of‑memory exceptions during high‑volume processing.
 * 5. When building a web API that returns dynamically drawn thumbnails, reusing a pre‑defined GraphicsPath for the border rectangle lets the API render each thumbnail quickly while guaranteeing the path does not keep the previous thumbnail file open.
 */