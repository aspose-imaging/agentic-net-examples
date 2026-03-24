using System;
using System.IO;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        using (JpegImage image = (JpegImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Create graphics for the image
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Define font
            Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);

            // Measure the string
            Aspose.Imaging.SizeF layoutArea = new Aspose.Imaging.SizeF(0, 0);
            Aspose.Imaging.StringFormat format = null;
            Aspose.Imaging.SizeF measuredSize = graphics.MeasureString("Sample Text", font, layoutArea, format);

            Console.WriteLine($"Measured size: Width={measuredSize.Width}, Height={measuredSize.Height}");

            // Draw the string onto the image
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Aspose.Imaging.Color.Black;
                brush.Opacity = 100;
                graphics.DrawString("Sample Text", font, brush, new Aspose.Imaging.PointF(10, 10));
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the modified image
            image.Save(outputPath);
        }
    }
}