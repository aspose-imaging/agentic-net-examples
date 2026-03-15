using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input and output PNG file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the PNG image
        using (PngImage png = (PngImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Resize the image using high-quality Lanczos resampling
            png.Resize(200, 200, Aspose.Imaging.ResizeType.LanczosResample);

            // Crop a region from the resized image
            png.Crop(new Aspose.Imaging.Rectangle(10, 10, 180, 180));

            // Draw a blue rectangle on the image
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(png);
            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);
            graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(20, 20, 100, 100));

            // Prepare PNG save options
            PngOptions options = new PngOptions
            {
                CompressionLevel = 6,
                Progressive = true
            };

            // Save the processed image as PNG
            png.Save(outputPath, options);
        }
    }
}