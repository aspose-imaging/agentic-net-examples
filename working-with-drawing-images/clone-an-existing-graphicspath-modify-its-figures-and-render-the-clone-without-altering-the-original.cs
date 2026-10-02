// HOW-TO: Clone and Modify a GraphicsPath Without Changing the Original in C# (Aspose.Imaging for .NET)
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
            // Output paths
            string outputPathOriginal = "original_output.bmp";
            string outputPathClone = "clone_output.bmp";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathOriginal));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathClone));

            // Canvas size
            int width = 500;
            int height = 500;

            // Create original GraphicsPath
            GraphicsPath originalPath = new GraphicsPath();
            Figure figure1 = new Figure();
            RectangleShape rectShape = new RectangleShape(new RectangleF(50, 50, 200, 150));
            figure1.AddShape(rectShape);
            originalPath.AddFigure(figure1);

            // Create cloned GraphicsPath by replicating original shapes
            GraphicsPath clonedPath = new GraphicsPath();
            Figure clonedFigure1 = new Figure();
            RectangleShape rectShapeClone = new RectangleShape(new RectangleF(50, 50, 200, 150));
            clonedFigure1.AddShape(rectShapeClone);
            clonedPath.AddFigure(clonedFigure1);

            // Modify the cloned path: add an ellipse shape
            Figure figure2 = new Figure();
            EllipseShape ellipseShape = new EllipseShape(new RectangleF(150, 200, 200, 150));
            figure2.AddShape(ellipseShape);
            clonedPath.AddFigure(figure2);

            // Create and draw on the original image
            BmpOptions bmpOptionsOriginal = new BmpOptions();
            bmpOptionsOriginal.Source = new FileCreateSource(outputPathOriginal, false);
            using (RasterImage imageOriginal = (RasterImage)Image.Create(bmpOptionsOriginal, width, height))
            {
                Graphics graphicsOriginal = new Graphics(imageOriginal);
                Pen penOriginal = new Pen(Color.Blue, 3);
                graphicsOriginal.DrawPath(penOriginal, originalPath);
                imageOriginal.Save();
            }

            // Create and draw on the cloned image
            BmpOptions bmpOptionsClone = new BmpOptions();
            bmpOptionsClone.Source = new FileCreateSource(outputPathClone, false);
            using (RasterImage imageClone = (RasterImage)Image.Create(bmpOptionsClone, width, height))
            {
                Graphics graphicsClone = new Graphics(imageClone);
                Pen penClone = new Pen(Color.Red, 3);
                graphicsClone.DrawPath(penClone, clonedPath);
                imageClone.Save();
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
 * 1. When you need to keep a base vector shape unchanged while creating a modified version for a different design layer, you can clone the GraphicsPath and add new figures.
 * 2. When generating multiple bitmap files from the same original drawing, cloning the path lets you render each variant without re‑creating the original shapes.
 * 3. When implementing an undo/redo feature in a drawing application, cloning the GraphicsPath before edits preserves the previous state for easy rollback.
 * 4. When you want to overlay additional shapes, such as an ellipse, onto an existing rectangle layout without affecting the original composition, a cloned path provides a safe workspace.
 * 5. When exporting both the original and edited graphics to separate BMP files for comparison or documentation, cloning ensures the original image remains intact while the clone reflects the changes.
 */
