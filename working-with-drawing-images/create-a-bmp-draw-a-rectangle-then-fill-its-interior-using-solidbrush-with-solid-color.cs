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
        // Hardcoded output path
        string outputPath = @"c:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options and bind the output file
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new BMP image with specified dimensions
        using (Image image = Image.Create(bmpOptions, 200, 200))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Define rectangle bounds
            Rectangle rect = new Rectangle(50, 50, 100, 100);

            // Fill the rectangle with a solid red brush
            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                graphics.FillRectangle(brush, rect);
            }

            // Draw the rectangle outline with a black pen
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawRectangle(pen, rect);

            // Save the image (file is already bound to the output path)
            image.Save();
        }
    }
}