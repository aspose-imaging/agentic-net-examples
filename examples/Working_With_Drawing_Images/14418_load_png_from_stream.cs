using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input PNG and output image
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load PNG image from a file stream
        using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        using (Image image = Image.Load(stream))
        {
            // Create a Graphics object for drawing on the loaded image
            Graphics graphics = new Graphics(image);

            // Example drawing: a red line
            Pen pen = new Pen(Color.Red, 5);
            graphics.DrawLine(pen, new Point(10, 10), new Point(200, 200));

            // Save the modified image
            image.Save(outputPath);
        }
    }
}