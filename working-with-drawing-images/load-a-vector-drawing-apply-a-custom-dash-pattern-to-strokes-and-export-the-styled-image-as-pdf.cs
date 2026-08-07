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
            string inputPath = "input/input.svg";
            string outputPath = "output/output.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics instance for drawing
                Graphics graphics = new Graphics(image);

                // Define a pen with custom dash pattern
                Pen pen = new Pen(Color.Black, 2);
                pen.DashPattern = new float[] { 5f, 3f }; // 5 units dash, 3 units space

                // Create a path (e.g., a rectangle) to apply the dash pattern
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 200)));
                path.AddFigure(figure);

                // Draw the path with the dashed pen
                graphics.DrawPath(pen, path);

                // Save the styled image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert an SVG floor‑plan into a PDF brochure while highlighting walls with a custom dashed stroke.
 * 2. When an engineering application must export circuit diagrams from SVG with a 5‑pixel dash and 3‑pixel gap to emphasize signal paths in a PDF report.
 * 3. When a web service generates printable invoices that contain vector logos and adds a dashed border around the logo before saving as PDF.
 * 4. When a GIS tool loads a vector map, applies a dash pattern to road polylines to differentiate highways, and saves the styled map as a PDF for distribution.
 * 5. When a desktop utility creates PDF certificates from SVG templates and uses a custom dash pattern to underline the recipient’s name for visual emphasis.
 */