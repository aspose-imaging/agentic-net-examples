using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define image dimensions
            int canvasWidth = 200;
            int canvasHeight = 200;

            // Define radii and corresponding colors for each BMP
            int[] radii = new int[] { 20, 40, 60 };
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue };

            for (int i = 0; i < radii.Length; i++)
            {
                int radius = radii[i];
                Color fillColor = colors[i];

                // Output file path (hardcoded)
                string outputPath = $"output_{radius}.bmp";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Create BMP options with bound file source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);
                bmpOptions.BitsPerPixel = 24;

                // Create the image canvas bound to the output file
                using (Image canvas = Image.Create(bmpOptions, canvasWidth, canvasHeight))
                {
                    // Clear background to white
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    // Calculate centered rectangle for the circle
                    int diameter = radius * 2;
                    int offsetX = (canvasWidth - diameter) / 2;
                    int offsetY = (canvasHeight - diameter) / 2;
                    Rectangle circleBounds = new Rectangle(offsetX, offsetY, diameter, diameter);

                    // Fill the circle with the specified color
                    using (SolidBrush brush = new SolidBrush(fillColor))
                    {
                        graphics.FillEllipse(brush, circleBounds);
                    }

                    // Save the bound image
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
 * 1. When a developer needs to create a set of BMP icons representing status indicators (e.g., low, medium, high) with different colored circles for a Windows desktop application.
 * 2. When a game developer wants to generate placeholder sprite sheets in BMP format containing centered colored circles of varying radii for testing collision detection logic.
 * 3. When an automation script must produce printable BMP markers with specific radii and colors for labeling components on a PCB layout.
 * 4. When a data‑visualization tool requires pre‑rendered BMP symbols of different sizes and hues to annotate points on a static map image.
 * 5. When a quality‑control system needs to batch create BMP test patterns with centered circles to verify scanner calibration across multiple resolutions.
 */