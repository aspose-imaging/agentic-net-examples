using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load existing GIF
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Use the first frame as active frame
            if (gif.PageCount > 0)
            {
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];
            }

            // Create graphics for the active frame
            Graphics graphics = new Graphics(gif.ActiveFrame);

            // Fill background with blue
            using (SolidBrush fillBrush = new SolidBrush(Color.Blue))
            {
                graphics.FillRectangle(fillBrush, gif.ActiveFrame.Bounds);

                // Draw shapes
                Pen redPen = new Pen(Color.Red, 3);
                graphics.DrawEllipse(redPen, new Rectangle(20, 20, 100, 100));
                graphics.DrawLine(redPen, new Point(0, 0), new Point(200, 200));
                graphics.DrawRectangle(redPen, new Rectangle(50, 50, 80, 60));

                // Draw text
                Font font = new Font("Arial", 12);
                graphics.DrawString("Sample Text", font, fillBrush, new PointF(10, 150));
            }

            // Save modified GIF
            gif.Save(outputPath, new GifOptions());
        }
    }
}