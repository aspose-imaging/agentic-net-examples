// HOW-TO: Create a Filled Blue Rectangle with Black Border in C# PNG (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\filled_rectangle.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Configure PNG options to write to the stream
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a new PNG image with desired dimensions
                using (Image image = Image.Create(pngOptions, 400, 300))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(image);

                    // Define the rectangle area
                    Rectangle rect = new Rectangle(50, 50, 300, 200);

                    // Fill the rectangle with solid blue brush
                    SolidBrush blueBrush = new SolidBrush(Color.Blue);
                    graphics.FillRectangle(blueBrush, rect);

                    // Outline the rectangle with a thick black pen (width = 5)
                    Pen blackPen = new Pen(Color.Black, 5);
                    graphics.DrawRectangle(blackPen, rect);

                    // Save the image to the stream
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
 * 1. When you need to generate a PNG badge or label with a solid blue background and a thick black outline using Aspose.Imaging in C#.
 * 2. When creating dynamic graphics for a web API that returns custom‑shaped images, such as highlighted selection boxes drawn with SolidBrush and Pen.
 * 3. When producing printable reports that require a simple colored rectangle as a placeholder or background element in a generated image.
 * 4. When building a Windows desktop application that draws UI components on the fly, like a highlighted button rendered to a PNG file with Aspose.Imaging.
 * 5. When automating test image creation to verify that fill and stroke operations work correctly in an image‑processing workflow.
 */
