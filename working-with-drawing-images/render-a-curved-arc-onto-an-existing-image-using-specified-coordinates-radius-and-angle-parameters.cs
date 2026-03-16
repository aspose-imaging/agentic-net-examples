using System;
using Aspose.Imaging;

public class Program
{
    public static void Main(string[] args)
    {
        // Path to the existing image
        string inputPath = "input.jpg";
        // Path for the output image
        string outputPath = "output.jpg";

        // Load the image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);

            // Arc parameters
            int centerX = 150;      // X-coordinate of the arc center
            int centerY = 100;      // Y-coordinate of the arc center
            int radius = 80;        // Radius of the arc
            int startAngle = 30;    // Starting angle in degrees
            int sweepAngle = 120;   // Sweep angle in degrees

            // Calculate the bounding rectangle of the arc
            int rectX = centerX - radius;
            int rectY = centerY - radius;
            int rectWidth = radius * 2;
            int rectHeight = radius * 2;

            // Create a pen for drawing the arc
            Pen pen = new Pen(Color.Blue, 3);

            // Draw the arc onto the image
            graphics.DrawArc(pen, rectX, rectY, rectWidth, rectHeight, startAngle, sweepAngle);

            // Save the modified image
            image.Save(outputPath);
        }
    }
}