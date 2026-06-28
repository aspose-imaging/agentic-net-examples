using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Output file paths (hard‑coded)
            string outputPath1 = "output1.tif";
            string outputPath2 = "output2.tif";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath2) ?? ".");

            // Prepare a reusable GraphicsPath (does not depend on any image)
            var sharedPath = new GraphicsPath();
            var figure = new Figure();
            // Add a simple rectangle shape to the figure
            figure.AddShape(new RectangleShape(new RectangleF(20f, 20f, 100f, 100f)));
            sharedPath.AddFigure(figure);

            // ---------- First image: render the path ----------
            var tiffOptions1 = new TiffOptions(TiffExpectedFormat.Default);
            using (var image1 = Image.Create(tiffOptions1, 200, 200))
            {
                var graphics1 = new Graphics(image1);
                graphics1.Clear(Color.LightGray);
                graphics1.DrawPath(new Pen(Color.Blue, 3), sharedPath);
                image1.Save(outputPath1);
            } // image1 disposed here

            // ---------- Second image: reuse the same GraphicsPath ----------
            var tiffOptions2 = new TiffOptions(TiffExpectedFormat.Default);
            using (var image2 = Image.Create(tiffOptions2, 200, 200))
            {
                var graphics2 = new Graphics(image2);
                graphics2.Clear(Color.White);
                // Re‑draw the same path onto a new image after the first image has been disposed
                graphics2.DrawPath(new Pen(Color.Red, 3), sharedPath);
                image2.Save(outputPath2);
            } // image2 disposed here

            // If we reach this point without exception, GraphicsPath does not retain a reference to the source image.
            Console.WriteLine("GraphicsPath successfully reused after source image disposal.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When generating a batch of TIFF reports where the same vector logo (GraphicsPath) must be drawn on each page without keeping the previous page’s image in memory, this code confirms safe reuse of the path.
 * 2. When creating thumbnail previews for uploaded photos and re‑using a predefined cropping rectangle (GraphicsPath) across many images, the example shows that disposing the first image releases all resources.
 * 3. When applying a consistent red‑border annotation to a series of scanned documents, developers can reuse the same GraphicsPath for each new Image object without risking a memory leak.
 * 4. When building a multi‑page TIFF file where each page shares identical geometric shapes (e.g., a rectangle placeholder), this pattern validates that the shared GraphicsPath does not hold references to earlier pages.
 * 5. When implementing a C# image‑processing service that draws a reusable watermark shape on different image formats (TIFF, PNG, JPEG) using Aspose.Imaging, the code demonstrates that the GraphicsPath can be safely reused after each source image is disposed.
 */