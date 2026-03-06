using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output PNG files
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load PNG image from a file stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        {
            using (PngImage pngImage = new PngImage(inputStream))
            {
                // Create a Graphics instance for drawing on the loaded image
                Graphics graphics = new Graphics(pngImage);

                // Draw a red rectangle border
                Pen pen = new Pen(Color.Red, 3);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));

                // Fill the same rectangle with blue color
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, new Rectangle(50, 50, 200, 150));
                }

                // Save the modified image to a new file
                pngImage.Save(outputPath);
            }
        }
    }
}