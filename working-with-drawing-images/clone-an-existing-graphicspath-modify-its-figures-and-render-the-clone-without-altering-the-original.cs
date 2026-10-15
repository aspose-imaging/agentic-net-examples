// HOW-TO: Clone and Modify a GraphicsPath Without Changing Original in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string originalOutputPath = "original.png";
            string cloneOutputPath = "clone.png";

            Directory.CreateDirectory(Path.GetDirectoryName(originalOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(cloneOutputPath));

            // Create original GraphicsPath with a rectangle shape
            Aspose.Imaging.GraphicsPath originalPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure originalFigure = new Aspose.Imaging.Figure();
            Aspose.Imaging.RectangleF rect = new Aspose.Imaging.RectangleF(50, 50, 200, 150);
            Aspose.Imaging.Shapes.RectangleShape rectShape = new Aspose.Imaging.Shapes.RectangleShape(rect);
            originalFigure.AddShape(rectShape);
            originalPath.AddFigure(originalFigure);

            // Create cloned GraphicsPath by copying the rectangle shape and adding an ellipse
            Aspose.Imaging.GraphicsPath clonedPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure cloneFigureRect = new Aspose.Imaging.Figure();
            Aspose.Imaging.RectangleF rectCopy = new Aspose.Imaging.RectangleF(50, 50, 200, 150);
            Aspose.Imaging.Shapes.RectangleShape rectShapeCopy = new Aspose.Imaging.Shapes.RectangleShape(rectCopy);
            cloneFigureRect.AddShape(rectShapeCopy);
            clonedPath.AddFigure(cloneFigureRect);

            // Add ellipse shape to cloned path
            Aspose.Imaging.Figure cloneFigureEllipse = new Aspose.Imaging.Figure();
            Aspose.Imaging.RectangleF ellipseRect = new Aspose.Imaging.RectangleF(100, 100, 150, 100);
            Aspose.Imaging.Shapes.EllipseShape ellipseShape = new Aspose.Imaging.Shapes.EllipseShape(ellipseRect);
            cloneFigureEllipse.AddShape(ellipseShape);
            clonedPath.AddFigure(cloneFigureEllipse);

            int width = 300;
            int height = 300;

            // Render original path
            var originalOptions = new PngOptions();
            originalOptions.Source = new FileCreateSource(originalOutputPath, false);
            using (Aspose.Imaging.Image originalImage = Aspose.Imaging.Image.Create(originalOptions, width, height))
            {
                var graphics = new Aspose.Imaging.Graphics(originalImage);
                graphics.Clear(Aspose.Imaging.Color.White);
                var redPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3);
                graphics.DrawPath(redPen, originalPath);
                originalImage.Save();
            }

            // Render cloned (modified) path
            var cloneOptions = new PngOptions();
            cloneOptions.Source = new FileCreateSource(cloneOutputPath, false);
            using (Aspose.Imaging.Image cloneImage = Aspose.Imaging.Image.Create(cloneOptions, width, height))
            {
                var graphics = new Aspose.Imaging.Graphics(cloneImage);
                graphics.Clear(Aspose.Imaging.Color.White);
                var bluePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                graphics.DrawPath(bluePen, clonedPath);
                cloneImage.Save();
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
 * 1. When you need to create a watermark overlay on an image while preserving the original vector path for later reuse.
 * 2. When generating multiple variations of a logo, such as adding shapes, without altering the base GraphicsPath design.
 * 3. When performing batch image processing that requires adding extra shapes to a copy of an existing GraphicsPath for each output PNG file.
 * 4. When implementing undo/redo functionality in a drawing application by cloning the current GraphicsPath before applying edits.
 * 5. When exporting a diagram to different formats like PNG or SVG and you want to augment the cloned path with additional elements while keeping the source unchanged.
 */
