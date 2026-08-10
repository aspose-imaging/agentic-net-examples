// HOW-TO: Create JPEG2000 Image With Custom Buffer And Solid Color Background In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = @"C:\temp\output.jp2";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a source bound to the output file
            Source fileSource = new FileCreateSource(outputPath, false);

            // Configure JPEG2000 options with custom memory strategy
            Jpeg2000Options jp2Options = new Jpeg2000Options
            {
                Source = fileSource,
                BufferSizeHint = 10 * 1024 * 1024, // 10 MB buffer
                Irreversible = true // optional: use irreversible DWT
            };

            int width = 200;
            int height = 200;

            // Create JPEG2000 image canvas
            using (Jpeg2000Image canvas = new Jpeg2000Image(width, height, jp2Options))
            {
                // Draw solid color background
                Graphics graphics = new Graphics(canvas);
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, canvas.Bounds);
                }

                // Save the bound image
                canvas.Save();
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
 * 1. When you need to generate a JPEG2000 file on the fly with a specific buffer size to avoid high memory consumption while filling the canvas with a uniform background color.
 * 2. When an application must create a lossless or near‑lossless JPEG2000 thumbnail for medical imaging or GIS data and requires a solid color placeholder before adding actual content.
 * 3. When a server‑side service processes large images and wants to write the output directly to disk using a FileCreateSource to control the file creation and memory usage.
 * 4. When you are building a batch job that programmatically creates blank JPEG2000 canvases of a fixed size for later overlay of graphics or text.
 * 5. When you need to use Aspose.Imaging’s Jpeg2000Options to enable irreversible DWT and custom buffer hints while initializing the image with a single‑color background for testing compression settings.
 */
