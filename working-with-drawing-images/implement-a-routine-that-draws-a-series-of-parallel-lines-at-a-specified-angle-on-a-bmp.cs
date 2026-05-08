using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 800;
            int height = 600;

            // Parallel line parameters
            double angleDegrees = 45;          // Angle of the lines
            int spacing = 20;                  // Distance between lines (pixels)
            Color lineColor = Color.Black;     // Line color
            int lineWidth = 2;                 // Line thickness

            // Prepare BMP options with a FileCreateSource bound to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Pre‑compute trigonometric values
                double rad = angleDegrees * Math.PI / 180.0;
                double cos = Math.Cos(rad);
                double sin = Math.Sin(rad);

                // Length sufficient to cover the whole canvas (diagonal)
                double diag = Math.Sqrt(width * width + height * height);
                int maxOffset = (int)diag;

                // Pen for drawing lines
                Pen pen = new Pen(lineColor, lineWidth);

                // Draw parallel lines across the image
                for (int offset = -maxOffset; offset <= maxOffset; offset += spacing)
                {
                    // Compute start point
                    int startX = (int)(width / 2 + offset * -sin);
                    int startY = (int)(height / 2 + offset * cos);

                    // Compute end point (extend by diagonal length)
                    int endX = (int)(startX + diag * cos);
                    int endY = (int)(startY + diag * sin);

                    graphics.DrawLine(pen, new Point(startX, startY), new Point(endX, endY));
                }

                // Save the image (output file already bound)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}