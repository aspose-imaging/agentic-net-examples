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
            // Output directory for generated BMP files
            string outputDir = @"C:\Temp\Shapes";
            Directory.CreateDirectory(outputDir);

            // Canvas dimensions
            int canvasWidth = 500;
            int canvasHeight = 500;

            // List of shapes to draw
            string[] shapeNames = new string[] { "Rectangle", "Ellipse", "Line", "Polygon", "Pie", "Arc" };

            foreach (string shape in shapeNames)
            {
                // Output file path for the current shape
                string outputPath = Path.Combine(outputDir, shape + ".bmp");

                // Ensure the output directory exists (rule 3)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure BMP options and bind to the output file
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;
                Source source = new FileCreateSource(outputPath, false);
                bmpOptions.Source = source;

                // Create the canvas image
                using (Image canvas = Image.Create(bmpOptions, canvasWidth, canvasHeight))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    // Common pen for drawing shapes
                    Pen pen = new Pen(Color.Black, 3);

                    // Draw the selected shape
                    switch (shape)
                    {
                        case "Rectangle":
                            graphics.DrawRectangle(pen, new Rectangle(50, 50, 400, 300));
                            break;
                        case "Ellipse":
                            graphics.DrawEllipse(pen, new Rectangle(50, 50, 400, 300));
                            break;
                        case "Line":
                            graphics.DrawLine(pen, new Point(50, 50), new Point(450, 450));
                            break;
                        case "Polygon":
                            graphics.DrawPolygon(pen, new[]
                            {
                                new Point(250, 50),
                                new Point(450, 250),
                                new Point(250, 450),
                                new Point(50, 250)
                            });
                            break;
                        case "Pie":
                            graphics.DrawPie(pen, new Rectangle(100, 100, 300, 300), 0, 120);
                            break;
                        case "Arc":
                            graphics.DrawArc(pen, new Rectangle(100, 100, 300, 300), 0, 120);
                            break;
                    }

                    // Save the canvas (output is already bound to the file)
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
 * 1. When a developer needs to automatically generate a set of BMP icons that each display a different geometric shape for use in a Windows desktop application's toolbar.
 * 2. When a testing team requires a batch of sample BMP images containing predefined shapes to validate image processing algorithms such as shape detection or edge detection in C#.
 * 3. When a documentation generator must create visual examples of drawing primitives (rectangle, ellipse, line, polygon, pie, arc) in BMP format to illustrate Aspose.Imaging graphics capabilities.
 * 4. When an e‑learning platform wants to programmatically produce lesson assets showing basic geometric figures in 24‑bit BMP files for inclusion in interactive quizzes.
 * 5. When a game developer needs to pre‑render simple shape sprites as BMP files to be loaded quickly at runtime without relying on external design tools.
 */