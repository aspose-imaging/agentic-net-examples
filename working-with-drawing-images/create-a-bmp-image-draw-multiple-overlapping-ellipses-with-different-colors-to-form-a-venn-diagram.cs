using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Output file path (hard‑coded)
        string outputPath = @"c:\temp\venn_diagram.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // BMP options with 24‑bit color depth
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500×500 canvas bound to the output file
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // First ellipse – semi‑transparent red
            using (SolidBrush brush1 = new SolidBrush())
            {
                brush1.Color = Color.Red;
                brush1.Opacity = 50; // 0‑100 range
                graphics.FillEllipse(brush1, new Rectangle(50, 150, 200, 200));
            }
            graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(50, 150, 200, 200));

            // Second ellipse – semi‑transparent green
            using (SolidBrush brush2 = new SolidBrush())
            {
                brush2.Color = Color.Green;
                brush2.Opacity = 50;
                graphics.FillEllipse(brush2, new Rectangle(150, 150, 200, 200));
            }
            graphics.DrawEllipse(new Pen(Color.Green, 2), new Rectangle(150, 150, 200, 200));

            // Third ellipse – semi‑transparent blue
            using (SolidBrush brush3 = new SolidBrush())
            {
                brush3.Color = Color.Blue;
                brush3.Opacity = 50;
                graphics.FillEllipse(brush3, new Rectangle(100, 250, 200, 200));
            }
            graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(100, 250, 200, 200));

            // Save the image (output already bound to the file)
            image.Save();
        }
    }
}