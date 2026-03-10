using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Path to the source TIFF file
        string inputPath = @"C:\Temp\input.tif";

        // Path to the output TIFF file
        string outputPath = @"C:\Temp\output.tif";

        // Load the existing TIFF image (lifecycle rule: load)
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Create a Graphics object for drawing on the active frame
            Graphics graphics = new Graphics(tiffImage.ActiveFrame);

            // Clear the background with a light gray color
            graphics.Clear(Color.LightGray);

            // Draw a red ellipse
            graphics.DrawEllipse(
                new Pen(Color.Red, 5),
                new Rectangle(50, 50, 200, 150));

            // Fill a blue rectangle
            graphics.FillRectangle(
                new SolidBrush(Color.Blue),
                new Rectangle(300, 100, 120, 80));

            // Draw a string using a TrueType font
            Font font = new Font("Arial", 24, FontStyle.Bold);
            graphics.DrawString(
                "Aspose.Imaging Demo",
                font,
                new SolidBrush(Color.Yellow),
                new PointF(60, 250));

            // Save the modified TIFF image (lifecycle rule: save)
            tiffImage.Save(outputPath);
        }
    }
}