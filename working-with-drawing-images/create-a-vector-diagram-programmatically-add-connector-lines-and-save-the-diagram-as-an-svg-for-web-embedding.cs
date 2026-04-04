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
        // Output SVG file path
        string outputPath = @"C:\temp\diagram.svg";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Canvas size
        int width = 800;
        int height = 600;
        int dpi = 96;

        // Create SVG graphics context
        var graphics = new SvgGraphics2D(width, height, dpi);

        // Common pen and brush
        var pen = new Pen(Color.Black, 2);
        var brush = new SolidBrush(Color.LightGray);

        // Draw first node rectangle and label
        graphics.FillRectangle(pen, brush, 100, 100, 150, 100);
        graphics.DrawRectangle(pen, 100, 100, 150, 100);
        graphics.DrawString(new Font("Arial", 24, FontStyle.Regular), "Node 1", new Point(125, 130), Color.Black);

        // Draw second node rectangle and label
        graphics.FillRectangle(pen, brush, 400, 100, 150, 100);
        graphics.DrawRectangle(pen, 400, 100, 150, 100);
        graphics.DrawString(new Font("Arial", 24, FontStyle.Regular), "Node 2", new Point(425, 130), Color.Black);

        // Draw third node rectangle and label
        graphics.FillRectangle(pen, brush, 250, 300, 150, 100);
        graphics.DrawRectangle(pen, 250, 300, 150, 100);
        graphics.DrawString(new Font("Arial", 24, FontStyle.Regular), "Node 3", new Point(275, 330), Color.Black);

        // Connector lines between node centers
        // Center points
        int cx1 = 100 + 75;  // 175
        int cy1 = 100 + 50;  // 150
        int cx2 = 400 + 75;  // 475
        int cy2 = 100 + 50;  // 150
        int cx3 = 250 + 75;  // 325
        int cy3 = 300 + 50;  // 350

        // Line between Node 1 and Node 2
        graphics.DrawLine(pen, cx1, cy1, cx2, cy2);
        // Line between Node 1 and Node 3
        graphics.DrawLine(pen, cx1, cy1, cx3, cy3);
        // Line between Node 2 and Node 3
        graphics.DrawLine(pen, cx2, cy2, cx3, cy3);

        // Finalize and save SVG
        using (SvgImage svgImage = graphics.EndRecording())
        {
            svgImage.Save(outputPath);
        }
    }
}