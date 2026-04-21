using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

public class Program
{
    static void Main(string[] args)
    {
        // Define output file path and ensure its directory exists
        string outputPath = "output/output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image canvas (500x500) bound to the stream
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing on the image
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define a blue pen for the Bezier curve
                Pen pen = new Pen(Color.Blue, 2);

                // Define four points for the high‑precision Bezier spline
                Point pt1 = new Point(50, 250);
                Point pt2 = new Point(150, 50);
                Point pt3 = new Point(350, 450);
                Point pt4 = new Point(450, 250);

                // Draw the Bezier curve using the Point overload
                graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

                // Save the image (stream is already bound, so no path needed)
                image.Save();
            }
        }
    }
}