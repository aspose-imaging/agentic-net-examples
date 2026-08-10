// HOW-TO: Create BMP Venn Diagram With Overlapping Colored Ellipses In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\venn.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Define pens with different colors
                Pen redPen = new Pen(Color.Red, 2);
                Pen greenPen = new Pen(Color.Green, 2);
                Pen bluePen = new Pen(Color.Blue, 2);

                // Draw three overlapping ellipses to form a Venn diagram
                graphics.DrawEllipse(redPen, new Rectangle(100, 150, 200, 200));
                graphics.DrawEllipse(greenPen, new Rectangle(200, 150, 200, 200));
                graphics.DrawEllipse(bluePen, new Rectangle(150, 250, 200, 200));

                // Save the image to the specified path
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
 * 1. When you need to generate a BMP file that visualizes set relationships as a Venn diagram for reports or presentations.
 * 2. When you want to programmatically draw overlapping colored shapes to illustrate data intersections in a Windows desktop application.
 * 3. When you require automated creation of high‑resolution bitmap diagrams for documentation without using external graphics editors.
 * 4. When you need to embed dynamically generated Venn diagrams into PDFs or Word documents by first saving them as BMP images.
 * 5. When you are building a testing suite that validates rendering of multiple ellipses and color handling in Aspose.Imaging for .NET.
 */
