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
            // Output BMP file path
            string outputPath = @"output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source for the BMP image
            Source source = new FileCreateSource(outputPath, false);

            // Set up BMP options with the source
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Define canvas size
            int width = 400;
            int height = 400;

            // Create the BMP canvas (bound to the file)
            using (Image canvas = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Parameters for nested arcs (progress ring)
                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = Math.Min(width, height) / 2 - 10; // margin from edges
                int arcThickness = 20; // thickness of each ring
                int ringCount = 5;

                for (int i = 0; i < ringCount; i++)
                {
                    // Calculate radius for the current ring
                    int radius = maxRadius - i * (arcThickness + 5);

                    // Define bounding rectangle for the arc
                    Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);

                    // Create a pen with varying color for visual effect
                    Color penColor = Color.FromArgb(255, 255 - i * 40, i * 40);
                    Pen pen = new Pen(penColor, arcThickness);

                    // Draw a full circle as an arc (0 start angle, 360 sweep angle)
                    graphics.DrawArc(pen, rect, 0, 360);
                }

                // Save the bound image (no need to specify path again)
                canvas.Save();
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
 * 1. When a developer needs to generate a BMP file that visualizes task completion as a multi‑layered progress ring for a Windows desktop dashboard.
 * 2. When an application must create a lightweight, device‑independent bitmap showing nested arcs to represent different stages of a workflow in a reporting tool.
 * 3. When a C# service creates custom status icons in BMP format with colored arcs for embedding in legacy software that only supports BMP images.
 * 4. When a developer wants to programmatically draw concentric progress arcs using Aspose.Imaging.Graphics to produce printable progress charts for manufacturing dashboards.
 * 5. When an automated build process generates BMP progress ring graphics to be displayed in a CI/CD pipeline UI that reads image files from the file system.
 */