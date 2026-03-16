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
        string outputPath = "output.bmp";
        int width = 400;
        int height = 300;

        // Create a file-bound source for the BMP image
        Source src = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions()
        {
            Source = src,
            BitsPerPixel = 24 // 24‑bit BMP
        };

        // Create the canvas image
        using (Image canvas = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear background
            graphics.Clear(Color.LightGray);

            // Draw a red rectangle
            Pen redPen = new Pen(Color.Red, 3);
            graphics.DrawRectangle(redPen, new Rectangle(50, 50, 200, 150));

            // Fill a blue ellipse
            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            {
                graphics.FillEllipse(blueBrush, new Rectangle(100, 80, 150, 100));
            }

            // Draw a text string
            Font font = new Font("Arial", 24);
            using (SolidBrush blackBrush = new SolidBrush(Color.Black))
            {
                graphics.DrawString("Aspose.Imaging BMP", font, blackBrush, new PointF(60, 220));
            }

            // Save the bound BMP image
            canvas.Save();
        }
    }
}