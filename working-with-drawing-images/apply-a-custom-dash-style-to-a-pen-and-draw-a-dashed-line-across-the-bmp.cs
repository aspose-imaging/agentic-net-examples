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
            // Output BMP file path
            string outputPath = @"C:\temp\custom_dash_line.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Image dimensions
            int width = 400;
            int height = 200;

            // Create the image bound to the output file
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a pen with a custom dash pattern
                Pen pen = new Pen(Color.Blue, 5f);
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { 10f, 5f, 2f, 5f }; // dash, space, dash, space

                // Draw a horizontal dashed line across the image
                graphics.DrawLine(pen, new Point(0, height / 2), new Point(width, height / 2));

                // Save the image (output path already bound)
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
 * 1. When a developer needs to generate a printable BMP report that highlights section boundaries with a custom blue dashed line using Aspose.Imaging for .NET.
 * 2. When creating a thumbnail preview of a scanned document where a custom dash pattern drawn with a Pen indicates the crop area on a BMP image.
 * 3. When producing a BMP diagram for a CAD‑like application that uses different DashStyle.Custom patterns to distinguish measurement lines in C#.
 * 4. When automating the generation of a BMP watermark that consists of a repeated custom dash pattern across the image for branding purposes.
 * 5. When building a UI component that renders a BMP background with a custom dashed separator line to visually group controls in a .NET application.
 */