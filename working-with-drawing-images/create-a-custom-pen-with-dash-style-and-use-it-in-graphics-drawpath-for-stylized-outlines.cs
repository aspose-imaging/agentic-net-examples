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
            // Hardcoded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the input image
            using (Image image = Image.Load(inputPath))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White); // Optional background clear

                // Create a GraphicsPath with a rectangle figure
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                path.AddFigure(figure);

                // Create a custom Pen with dash style
                Pen pen = new Pen(Color.Blue, 3f);
                pen.DashStyle = DashStyle.Dash; // Set dash pattern

                // Draw the path using the custom Pen
                graphics.DrawPath(pen, path);

                // Save the modified image as PNG
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate a PNG thumbnail with a blue dashed rectangle overlay to highlight a region of interest in a UI screenshot.
 * 2. When a reporting tool must add stylized, dashed borders around chart legends in a generated PNG image for clearer visual separation.
 * 3. When an e‑commerce platform creates product images and requires a dashed outline to indicate a promotional “sale” area without modifying the original photo.
 * 4. When a document processing application programmatically draws a dashed rectangle on scanned PDFs converted to PNG to mark confidential sections.
 * 5. When a GIS application exports map tiles as PNG files and uses a custom Pen with dash style to draw selectable area boundaries for user interaction.
 */