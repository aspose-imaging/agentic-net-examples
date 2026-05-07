using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 200, 200))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Set high quality interpolation before scaling
                graphics.InterpolationMode = Aspose.Imaging.InterpolationMode.HighQualityBicubic;

                // Scale the drawing by 2x
                graphics.ScaleTransform(2.0f, 2.0f);

                // Draw a rectangle (will be scaled)
                graphics.DrawRectangle(
                    new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3),
                    new Aspose.Imaging.Rectangle(20, 20, 50, 50));

                // Save the BMP image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}