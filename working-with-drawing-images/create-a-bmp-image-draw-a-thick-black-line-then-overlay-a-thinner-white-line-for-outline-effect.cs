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
            // Output BMP file path (hard‑coded)
            string outputPath = @"C:\Temp\outline.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options and bind the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define image dimensions
            int width = 300;
            int height = 300;

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Define line start and end points
                Point start = new Point(50, 50);
                Point end = new Point(250, 250);

                // Draw a thick black line
                Pen blackPen = new Pen(Color.Black, 10);
                graphics.DrawLine(blackPen, start, end);

                // Overlay a thinner white line for outline effect
                Pen whitePen = new Pen(Color.White, 2);
                graphics.DrawLine(whitePen, start, end);

                // Save the image (file is already bound to outputPath)
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
 * 1. When a C# developer needs to generate a BMP file with a highlighted vector line for a technical diagram, they can use Aspose.Imaging to draw a thick black line and overlay a thin white line to create an outline effect.
 * 2. When building a Windows desktop application that exports custom grid overlays as BMP images, this code lets you render bold black grid lines with a subtle white border for better visual contrast.
 * 3. When creating printable engineering schematics in .NET where line visibility must be enhanced on monochrome BMP prints, the approach of drawing a thick black line followed by a thinner white line provides a clear outline.
 * 4. When developing a game asset pipeline that requires BMP textures with stylized borders around path lines, the sample demonstrates how to use Aspose.Imaging graphics and pens to achieve the effect programmatically.
 * 5. When automating the generation of BMP signatures or watermarks with a distinct outline for branding purposes, this code shows how to draw a solid black line and add a white outline using C# and Aspose.Imaging.
 */