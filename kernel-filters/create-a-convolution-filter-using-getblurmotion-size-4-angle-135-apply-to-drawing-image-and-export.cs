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
            string outputPath = "output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            int width = 300;
            int height = 200;

            using (Image image = Image.Create(pngOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black);
                graphics.DrawLine(pen, new Point(10, 10), new Point(290, 190));

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
 * 1. When a developer needs to add a realistic motion‑blur effect to a dynamically generated diagram (e.g., a line chart) before saving it as a PNG file using Aspose.Imaging for .NET.
 * 2. When an application must programmatically create a thumbnail of a CAD drawing and apply a 135‑degree motion blur to simulate camera movement for a preview pane.
 * 3. When a reporting tool generates vector‑based schematics on the fly and wants to soften edges with a size‑4 motion blur filter to improve visual hierarchy in PDF or PNG exports.
 * 4. When a game‑asset pipeline requires automated rendering of UI elements with a directional blur to convey speed, using the GetBlurMotion filter and then exporting the result as a transparent PNG.
 * 5. When a web service creates custom signatures or watermarks on images and applies a motion‑blur convolution to make the overlay appear as if it were stamped by a moving pen before returning the PNG to the client.
 */