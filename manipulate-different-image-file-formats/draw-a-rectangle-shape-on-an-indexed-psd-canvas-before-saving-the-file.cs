// HOW-TO: Draw A Black Rectangle On A PSD Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = @"C:\temp\output.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PSD options (default settings)
            var psdOptions = new PsdOptions();

            // Create a new PSD image with width and height
            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                // Initialize graphics for drawing
                var graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define a pen for the rectangle
                var pen = new Pen(Color.Black, 5);

                // Define rectangle bounds
                var rect = new Rectangle(50, 50, 400, 400);

                // Draw the rectangle on the canvas
                graphics.DrawRectangle(pen, rect);

                // Save the image to the specified path using the same PSD options
                image.Save(outputPath, psdOptions);
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
 * 1. When you need to programmatically add a border or highlight area in a Photoshop PSD file for automated design workflows.
 * 2. When generating template PSD files with placeholder shapes for later editing by graphic designers.
 * 3. When creating batch‑processed PSD assets that require a consistent rectangular frame around each image.
 * 4. When building a C# application that marks regions of interest on PSD layers for documentation or review purposes.
 * 5. When automating the preparation of PSD files for printing, adding a black rectangle as a crop or bleed guide.
 */
