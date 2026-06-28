using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string outputPath = @"C:\Temp\arc_output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500×500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Obtain a Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Define a blue pen with 2‑pixel width
                Pen pen = new Pen(Color.Blue, 2);

                // Precise rectangle using floating‑point values
                RectangleF rect = new RectangleF(50.5f, 50.5f, 200.75f, 150.25f);

                // Draw an arc: start at 45°, sweep 270°
                graphics.DrawArc(pen, rect, 45f, 270f);

                // Save the image (the file was already created by FileCreateSource)
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
 * 1. When a developer must generate a high‑resolution BMP report that includes accurately positioned curved annotations, such as a 45°‑to‑315° arc drawn with sub‑pixel precision using Aspose.Imaging’s Graphics.DrawArc and RectangleF.
 * 2. When creating custom UI mockups or wireframes in C# where precise arc shapes need to be rendered on a 500×500 BMP canvas for later export to design tools.
 * 3. When automating the production of engineering diagrams that require exact placement of arcs within a defined floating‑point rectangle, ensuring consistent measurements across different DPI settings.
 * 4. When building a server‑side image‑generation service that outputs 24‑bit BMP files with anti‑aliased arcs for printable marketing materials, leveraging the Pen width and floating‑point rectangle for fine‑tuned visual quality.
 * 5. When developing a scientific visualization that plots circular data ranges on a bitmap and needs the start angle and sweep angle to be specified in degrees with sub‑pixel accuracy for accurate data representation.
 */