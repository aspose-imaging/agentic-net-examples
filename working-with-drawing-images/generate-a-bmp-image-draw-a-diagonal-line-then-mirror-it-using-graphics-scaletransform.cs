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
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);

                // Draw original diagonal line
                Pen blackPen = new Pen(Color.Black, 2);
                graphics.DrawLine(blackPen, new Point(0, 0), new Point(width, height));

                // Apply horizontal mirror transform
                graphics.ScaleTransform(-1, 1);
                graphics.TranslateTransform(width, 0);

                // Draw mirrored diagonal line
                Pen redPen = new Pen(Color.Red, 2);
                graphics.DrawLine(redPen, new Point(0, 0), new Point(width, height));

                // Save the image (output is already bound via FileCreateSource)
                image.Save();
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
 * 1. When creating a simple BMP placeholder image for a legacy Windows application that requires a black diagonal line and its mirrored red counterpart for UI testing.
 * 2. When generating diagnostic graphics in a C# console tool to visualize coordinate transformations, such as confirming that ScaleTransform correctly mirrors shapes across the vertical axis.
 * 3. When producing a basic watermark template in BMP format where a diagonal line is duplicated in opposite directions to illustrate symmetry for branding guidelines.
 * 4. When building an automated test that compares original and mirrored drawing operations by rendering both lines in a single BMP file to verify the graphics pipeline of Aspose.Imaging.
 * 5. When needing to export a quick visual reference for documentation that shows how horizontal mirroring using Graphics.ScaleTransform affects line rendering in a 200×200 pixel image.
 */