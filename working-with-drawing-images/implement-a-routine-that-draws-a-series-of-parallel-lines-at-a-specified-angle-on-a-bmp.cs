// HOW-TO: Draw Parallel Lines at an Angle on a BMP with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP path (hard‑coded)
            string outputPath = @"output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Canvas size and drawing parameters
            int width = 800;
            int height = 600;
            double angleDegrees = 30.0;          // Angle of the lines
            int spacing = 20;                    // Distance between parallel lines (pixels)
            Aspose.Imaging.Color lineColor = Aspose.Imaging.Color.Black;
            int lineWidth = 2;

            // Prepare BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                // Obtain a Graphics object for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Pre‑compute trigonometric values
                double angleRad = angleDegrees * Math.PI / 180.0;
                double cos = Math.Cos(angleRad);
                double sin = Math.Sin(angleRad);
                double lineLength = Math.Sqrt(width * width + height * height) * 2.0;

                // Number of lines needed to cover the canvas
                int lineCount = (int)((width + height) / spacing) + 2;

                // Center of the canvas
                double centerX = width / 2.0;
                double centerY = height / 2.0;

                // Pen for drawing
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(lineColor, lineWidth);

                // Draw parallel lines
                for (int i = -lineCount; i <= lineCount; i++)
                {
                    double offset = i * spacing;

                    // Offset along the perpendicular direction
                    double cx = centerX + offset * (-sin);
                    double cy = centerY + offset * cos;

                    // Endpoints of the line
                    double x1 = cx - (lineLength / 2.0) * cos;
                    double y1 = cy - (lineLength / 2.0) * sin;
                    double x2 = cx + (lineLength / 2.0) * cos;
                    double y2 = cy + (lineLength / 2.0) * sin;

                    graphics.DrawLine(
                        pen,
                        (int)Math.Round(x1),
                        (int)Math.Round(y1),
                        (int)Math.Round(x2),
                        (int)Math.Round(y2));
                }

                // Save the image (output path already bound)
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
 * 1. When you need to generate a diagonal hatch pattern as a BMP background for UI components or game textures using C#.
 * 2. When creating custom engineering drawing fills where evenly spaced parallel lines at a specific angle must be saved as a BMP file.
 * 3. When producing printable alignment guides or barcode‑style markers for packaging layouts that require precise line spacing and orientation.
 * 4. When adding a simple security watermark of angled parallel lines to scanned BMP documents to deter unauthorized modifications.
 * 5. When synthesizing training images for computer‑vision models that need controlled line angles and spacing in BMP format.
 */
