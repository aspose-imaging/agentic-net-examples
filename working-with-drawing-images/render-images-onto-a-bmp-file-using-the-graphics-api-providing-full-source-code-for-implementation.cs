using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image that will be drawn onto the BMP
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Create a new 500x500 BMP image
            using (BmpImage bmpImage = new BmpImage(500, 500))
            {
                // Obtain a Graphics object for drawing
                Graphics graphics = new Graphics(bmpImage);

                // Fill the entire BMP background with light gray
                SolidBrush backgroundBrush = new SolidBrush(Color.LightGray);
                graphics.FillRectangle(backgroundBrush, new Rectangle(0, 0, bmpImage.Width, bmpImage.Height));

                // Draw the loaded image onto the BMP at position (50,50)
                graphics.DrawImage(sourceImage, new Rectangle(50, 50, sourceImage.Width, sourceImage.Height));

                // Draw a red ellipse on the BMP
                SolidBrush redBrush = new SolidBrush(Color.Red);
                graphics.FillEllipse(redBrush, new Rectangle(300, 200, 150, 100));

                // Save the resulting BMP file
                bmpImage.Save(outputPath);
            }
        }
    }
}