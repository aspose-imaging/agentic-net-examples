using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define output path (hard‑coded)
        string outputPath = "output/output.jpg";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Canvas size
        int width = 800;
        int height = 600;

        // JPEG creation options
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = new FileCreateSource(outputPath, false),
            Quality = 100
        };

        // Create bound JPEG canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, width, height))
        {
            // Graphics instance for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear background
            graphics.Clear(Color.White);

            // Draw a black rectangle
            Pen blackPen = new Pen(Color.Black, 3);
            graphics.DrawRectangle(blackPen, new Rectangle(50, 50, 300, 200));

            // Draw a red ellipse
            Pen redPen = new Pen(Color.Red, 2);
            graphics.DrawEllipse(redPen, new Rectangle(400, 100, 200, 150));

            // Draw a blue diagonal line
            Pen bluePen = new Pen(Color.Blue, 4);
            graphics.DrawLine(bluePen, new Point(0, 0), new Point(width, height));

            // Draw a text string
            Font font = new Font("Arial", 24);
            SolidBrush textBrush = new SolidBrush(Color.DarkGreen);
            graphics.DrawString("Aspose.Imaging Demo", font, textBrush, new PointF(200, 500));

            // Save the bound image
            canvas.Save();
        }
    }
}