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
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Define BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image canvas (800x200)
            using (Image image = Image.Create(bmpOptions, 800, 200))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Create a pen with custom dash pattern
                Pen pen = new Pen(Color.Black, 5f);
                pen.DashStyle = Aspose.Imaging.DashStyle.Custom;
                pen.DashPattern = new float[] { 10f, 5f, 2f, 5f }; // dash, space, dash, space

                // Draw a horizontal dashed line across the image
                graphics.DrawLine(pen, new Point(0, 100), new Point(800, 100));

                // Save the image (output path is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a 24‑bit BMP schematic and add a custom‑styled dashed separator line using Aspose.Imaging’s Pen and DashPattern features.
 * 2. When creating a printable BMP watermark that includes a black dashed line to visually separate confidential sections in a document.
 * 3. When building a UI prototype in C# where a dashed guideline drawn on an 800×200 BMP helps designers align controls during layout testing.
 * 4. When exporting a project timeline to a BMP image and using a custom dash pattern to highlight milestone markers with Aspose.Imaging graphics.
 * 5. When automating the production of BMP label templates that require a dashed cut‑line across the image to guide manual trimming.
 */