using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string outputPath = @"C:\temp\vector_diagram.svg";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create an SVG canvas
            int width = 800;
            int height = 600;
            int dpi = 96;
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw a border around the canvas
            graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, width, height);

            // Define two rectangles that will act as diagram nodes
            int nodeWidth = 120;
            int nodeHeight = 80;

            // First node at (150,200)
            int node1X = 150;
            int node1Y = 200;
            graphics.DrawRectangle(new Pen(Color.DarkBlue, 2), node1X, node1Y, nodeWidth, nodeHeight);
            graphics.DrawString(
                new Font("Arial", 14, FontStyle.Regular),
                "Node A",
                new Point(node1X + 20, node1Y + 30),
                Color.DarkBlue);

            // Second node at (500,200)
            int node2X = 500;
            int node2Y = 200;
            graphics.DrawRectangle(new Pen(Color.DarkGreen, 2), node2X, node2Y, nodeWidth, nodeHeight);
            graphics.DrawString(
                new Font("Arial", 14, FontStyle.Regular),
                "Node B",
                new Point(node2X + 20, node2Y + 30),
                Color.DarkGreen);

            // Draw a connector line between the centers of the two nodes
            int node1CenterX = node1X + nodeWidth / 2;
            int node1CenterY = node1Y + nodeHeight / 2;
            int node2CenterX = node2X + nodeWidth / 2;
            int node2CenterY = node2Y + nodeHeight / 2;
            graphics.DrawLine(new Pen(Color.Gray, 1), node1CenterX, node1CenterY, node2CenterX, node2CenterY);

            // Finalize the SVG image and save it
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath);
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
 * 1. When a developer needs to generate a dynamic flowchart or network diagram on the fly in a web application and embed it as an SVG without relying on client‑side drawing libraries.
 * 2. When an automated reporting tool must create printable architecture diagrams with labeled nodes and connector lines and export them as scalable SVG files for inclusion in HTML dashboards.
 * 3. When a SaaS platform wants to render real‑time organizational charts server‑side using C# and Aspose.Imaging, then serve the SVG to browsers for responsive scaling.
 * 4. When a documentation generator has to programmatically add labeled rectangles and arrows to illustrate API call sequences and save the result as an SVG for embedding in Markdown or Confluence pages.
 * 5. When a CI/CD pipeline needs to produce visual dependency graphs from build metadata, using Aspose.Imaging to draw node boxes, connect them, and store the output as an SVG for version‑controlled assets.
 */