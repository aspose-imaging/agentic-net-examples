using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\fullcircle.png";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a FileCreateSource bound to the output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw a full circle using DrawArc with start angle 0 and sweep angle 360
                graphics.DrawArc(new Pen(Color.Black, 2), new Rectangle(100, 100, 300, 300), 0, 360);

                // Save the image (output is already bound to the file)
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
 * 1. When a developer needs to generate a PNG badge that includes a perfect circular border for a user profile picture using Aspose.Imaging in C#.
 * 2. When creating a printable PDF report that requires a vector‑based circle drawn on a 500×500 image canvas before embedding it as a PNG thumbnail.
 * 3. When building a data‑visualization dashboard that programmatically draws circular progress indicators as full circles with a black outline.
 * 4. When automating the production of QR‑code placeholders that need a surrounding circle drawn with Graphics.DrawArc for branding purposes.
 * 5. When developing a testing tool that validates image rendering by programmatically creating a full circle in a PNG file to compare against expected output.
 */