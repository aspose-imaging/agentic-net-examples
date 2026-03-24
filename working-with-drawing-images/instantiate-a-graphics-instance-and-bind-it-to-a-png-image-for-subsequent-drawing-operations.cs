using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG options (default settings)
        PngOptions pngOptions = new PngOptions();

        // Create a new PNG image of size 500x500
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Bind a Graphics instance to the image
            Graphics graphics = new Graphics(image);

            // Example drawing operation: fill the background with LightBlue
            SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.LightBlue);
            graphics.FillRectangle(brush, image.Bounds);

            // Save the image to the specified output path
            image.Save(outputPath);
        }
    }
}