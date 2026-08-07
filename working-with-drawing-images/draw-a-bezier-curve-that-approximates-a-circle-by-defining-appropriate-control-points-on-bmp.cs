using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputPath = @"C:\temp\input.bmp";   // not used but kept to satisfy input‑path rule
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Input file existence check (rule 2)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (rule 3)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a blank BMP image (500x500)
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Prepare graphics surface
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for drawing the curve
                Pen pen = new Pen(Color.Blue, 2);

                // Circle approximation using four cubic Bézier curves
                float cx = 250f;          // center X
                float cy = 250f;          // center Y
                float r = 100f;           // radius
                float k = 0.5522847498f * r; // control point offset

                // Top‑right quadrant
                graphics.DrawBezier(pen,
                    new PointF(cx, cy - r),                 // start point
                    new PointF(cx + k, cy - r),             // control point 1
                    new PointF(cx + r, cy - k),             // control point 2
                    new PointF(cx + r, cy));                // end point

                // Bottom‑right quadrant
                graphics.DrawBezier(pen,
                    new PointF(cx + r, cy),                 // start point
                    new PointF(cx + r, cy + k),             // control point 1
                    new PointF(cx + k, cy + r),             // control point 2
                    new PointF(cx, cy + r));                // end point

                // Bottom‑left quadrant
                graphics.DrawBezier(pen,
                    new PointF(cx, cy + r),                 // start point
                    new PointF(cx - k, cy + r),             // control point 1
                    new PointF(cx - r, cy + k),             // control point 2
                    new PointF(cx - r, cy));                // end point

                // Top‑left quadrant
                graphics.DrawBezier(pen,
                    new PointF(cx - r, cy),                 // start point
                    new PointF(cx - r, cy - k),             // control point 1
                    new PointF(cx - k, cy - r),             // control point 2
                    new PointF(cx, cy - r));                // end point

                // Save the image (rule 3 already applied)
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Global error handling (rule 4)
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a high‑resolution BMP file that contains a mathematically accurate circle drawn with cubic Bézier curves for use in CAD or printing workflows.
 * 2. When an application must programmatically create a blank 500×500 image and overlay a blue circular outline as a template for UI icons or watermark stamps.
 * 3. When a .NET service has to export vector‑based circle graphics to a raster BMP format without relying on GDI+, using Aspose.Imaging’s Graphics.DrawBezier method.
 * 4. When a developer wants to illustrate the control‑point geometry of a circle approximation in educational software by drawing the four Bézier segments on a white background.
 * 5. When an automated image‑processing pipeline requires a consistent BMP placeholder that contains a circle shape for later detection or comparison in computer‑vision tests.
 */