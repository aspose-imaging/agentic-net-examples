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
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load source image (used only to obtain dimensions)
            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                // Create a new canvas image bound to the output file
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
                using (Image canvas = Image.Create(pngOptions, source.Width, source.Height))
                {
                    // Initialize graphics for the canvas
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    // Build a graphics path (rectangle shape)
                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, source.Width - 20f, source.Height - 20f)));
                    path.AddFigure(figure);

                    // Render the path onto the canvas
                    graphics.DrawPath(new Pen(Color.Black, 2), path);

                    // Save the canvas; output is already bound via FileCreateSource
                    canvas.Save();
                }
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
 * 1. When you need to convert a BMP file to a PNG with a black rectangular border while guaranteeing that the GraphicsPath releases the original bitmap so large images can be processed without excessive memory usage.
 * 2. When generating a blank‑canvas PNG of the same size as an existing image for watermarking or annotation, and you want to confirm that the drawing operations (GraphicsPath) do not keep the source image alive after rendering.
 * 3. When building a batch image‑processing pipeline that reads BMP files, draws simple shapes, and writes PNG output, this pattern validates that the source image can be disposed immediately after its dimensions are used.
 * 4. When creating a thumbnail or preview image that only needs the original dimensions and a drawn rectangle, the code demonstrates how to avoid lingering references that could prevent the source file from being deleted or overwritten.
 * 5. When implementing a server‑side service that receives user‑uploaded BMPs, adds a decorative frame, and returns a PNG, using this approach ensures the GraphicsPath does not retain the uploaded image, allowing the temporary file to be cleaned up promptly.
 */