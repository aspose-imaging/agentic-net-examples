// HOW-TO: Generate Multiple Rotated BMP Images from a Base Shape in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            int width = 200;
            int height = 200;
            int shapeSize = 100;
            int[] angles = new int[] { 0, 90, 180, 270 };

            foreach (int angle in angles)
            {
                string outputPath = Path.Combine(outputDirectory, $"rotated_{angle}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                BmpOptions options = new BmpOptions();
                options.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(options, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    graphics.TranslateTransform(width / 2f, height / 2f);
                    graphics.RotateTransform(angle);
                    graphics.TranslateTransform(-width / 2f, -height / 2f);

                    Pen pen = new Pen(Color.Black);
                    int x = (width - shapeSize) / 2;
                    int y = (height - shapeSize) / 2;
                    graphics.DrawRectangle(pen, x, y, shapeSize, shapeSize);

                    image.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create a series of BMP icons showing a logo at 0°, 90°, 180°, and 270° for a desktop application's toolbar.
 * 2. When generating test images for automated visual regression testing that require the same shape rotated at fixed angles.
 * 3. When preparing sprite sheets for a game where each frame is a rotated version of a base object stored as separate BMP files.
 * 4. When producing documentation screenshots that illustrate how a diagram looks after different rotations without manually editing each image.
 * 5. When batch-exporting engineering diagrams as BMP files with precise rotation for inclusion in legacy CAD systems that only accept BMP format.
 */
