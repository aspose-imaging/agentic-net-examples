using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Cache data for better performance
                if (!image.IsCached) image.CacheData();

                // Create a Graphics instance for drawing
                Graphics graphics = new Graphics(image);

                // Apply translation to shift all subsequent drawing operations
                float offsetX = 50f; // horizontal shift
                float offsetY = 30f; // vertical shift
                graphics.TranslateTransform(offsetX, offsetY);

                // Build a GraphicsPath containing a single rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                // Rectangle at (0,0) with size 100x100; translation will move it
                figure.AddShape(new RectangleShape(new RectangleF(0f, 0f, 100f, 100f)));
                path.AddFigure(figure);

                // Draw the path with a red pen
                Pen pen = new Pen(Color.Red, 3);
                graphics.DrawPath(pen, path);

                // Save the modified image as PNG
                PngOptions saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to add a consistent margin or offset to a vector shape—such as moving a logo rectangle 50 px right and 30 px down—before drawing it onto a PNG image.
 * 2. When generating dynamic thumbnails where watermarks or decorative frames must be positioned relative to the original image dimensions using a translation transform.
 * 3. When creating a batch‑processing tool that re‑positions UI elements in screenshots (e.g., shifting buttons) without altering the source file, by applying TranslateTransform to a GraphicsPath.
 * 4. When implementing a custom annotation system that places red rectangular highlights at a calculated offset on medical imaging files saved as PNG.
 * 5. When building a layout engine that aligns multiple shapes on a raster canvas by applying a uniform offset to each shape through Graphics.TranslateTransform before rendering.
 */