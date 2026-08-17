// HOW-TO: Set Brush Opacity for Transparent Shape Fill in C# PNG (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the source image
            using (Aspose.Imaging.Image inputImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int width = inputImage.Width;
                int height = inputImage.Height;

                // Create output image
                var pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
                using (Aspose.Imaging.Image outputImage = Aspose.Imaging.Image.Create(pngOptions, width, height))
                {
                    // Initialize graphics
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(outputImage);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Build a simple rectangular path
                    Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                    figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, width - 100f, height - 100f)));
                    Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                    path.AddFigure(figure);

                    // Create a brush with adjusted opacity
                    using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                    {
                        brush.Opacity = 0.5f; // 50% opacity
                        graphics.FillPath(brush, path);
                    }

                    // Save the result
                    outputImage.Save();
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
 * 1. When you need to overlay a semi‑transparent colored rectangle on a PNG using Aspose.Imaging in C# to highlight a region without obscuring the background.
 * 2. When creating dynamic watermarks where the opacity of a shape or text must be adjusted programmatically with Aspose.Imaging’s SolidBrush in C#.
 * 3. When generating UI mockups that require partially transparent UI elements such as buttons or panels drawn onto images with Aspose.Imaging graphics.
 * 4. When processing scanned documents and you want to add a translucent annotation box using a brush opacity setting in Aspose.Imaging C# code.
 * 5. When building a reporting tool that adds colored, semi‑transparent overlays to charts or maps exported as PNG files via Aspose.Imaging.
 */
