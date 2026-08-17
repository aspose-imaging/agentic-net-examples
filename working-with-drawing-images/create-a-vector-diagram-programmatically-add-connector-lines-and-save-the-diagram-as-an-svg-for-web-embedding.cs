// HOW-TO: Create SVG Diagram With Connectors Programmatically In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output SVG file path (hard‑coded)
            string outputPath = "diagram.svg";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Canvas dimensions
            int width = 800;
            int height = 600;
            int dpi = 96;

            // Create the SVG graphics canvas
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Define pens and brushes
            Pen nodePen = new Pen(Color.Black, 2);
            SolidBrush nodeFill = new SolidBrush(Color.LightGray);
            Pen connectorPen = new Pen(Color.Blue, 2);

            // Draw first node (rectangle)
            graphics.FillRectangle(nodePen, nodeFill, 100, 100, 150, 100);

            // Draw second node (rectangle)
            graphics.FillRectangle(nodePen, nodeFill, 550, 350, 150, 100);

            // Compute centers of the rectangles
            int x1 = 100 + 150 / 2;
            int y1 = 100 + 100 / 2;
            int x2 = 550 + 150 / 2;
            int y2 = 350 + 100 / 2;

            // Draw connector line between the nodes
            graphics.DrawLine(connectorPen, x1, y1, x2, y2);

            // Add text labels to the nodes
            Font labelFont = new Font("Arial", 24, FontStyle.Regular);
            graphics.DrawString(labelFont, "Node A", new Point(120, 130), Color.Black);
            graphics.DrawString(labelFont, "Node B", new Point(570, 380), Color.Black);

            // Finalize and save the SVG image
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
 * 1. When you need to generate a flowchart or network diagram on the fly in a web application and embed it as scalable SVG without using external design tools.
 * 2. When an automated reporting system must create labeled nodes with lines to visualize relationships between entities and export them as SVG for responsive web pages.
 * 3. When a SaaS platform wants to render dynamic architecture diagrams in real time, using C# code to draw rectangles, connectors, and text, then serve the SVG to browsers.
 * 4. When you are building a diagramming feature that stores diagram definitions in a database and recreates them as SVG images for download or preview.
 * 5. When you need to programmatically produce lightweight vector graphics for documentation or tutorials, ensuring the output scales cleanly on high‑DPI displays.
 */
