using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        // Input and output PSD file paths
        string inputPath = "input.psd";
        string outputPath = "output.psd";

        // Load the existing PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas (optional)
            graphics.Clear(Color.Transparent);

            // Draw a red rectangle
            Pen redPen = new Pen(Color.Red);
            graphics.DrawRectangle(redPen, new Rectangle(50, 50, 200, 150));

            // Fill a blue ellipse
            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            {
                graphics.FillEllipse(blueBrush, new Rectangle(300, 100, 150, 100));
            }

            // Draw text onto the PSD
            using (SolidBrush blackBrush = new SolidBrush(Color.Black))
            {
                Font font = new Font("Arial", 24);
                graphics.DrawString("Hello PSD", font, blackBrush, new Point(100, 250));
            }

            // Prepare PSD save options (default settings)
            PsdOptions psdOptions = new PsdOptions();

            // Save the modified image as a PSD file
            image.Save(outputPath, psdOptions);
        }
    }
}