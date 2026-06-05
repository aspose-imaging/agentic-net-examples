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
            // Reuse a single Pen instance across all images
            Pen sharedPen = new Pen(Color.Blue, 5);

            string[] outputPaths = { "output1.bmp", "output2.bmp", "output3.bmp" };
            int width = 300;
            int height = 200;

            foreach (var outputPath in outputPaths)
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                // Set up BMP options with a stream source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;

                using (FileStream stream = new FileStream(outputPath, FileMode.Create))
                {
                    bmpOptions.Source = new StreamSource(stream);

                    using (Image image = Image.Create(bmpOptions, width, height))
                    {
                        Graphics graphics = new Graphics(image);
                        graphics.Clear(Color.White);

                        // Draw a rectangle using the shared Pen
                        graphics.DrawRectangle(sharedPen, new Rectangle(20, 20, width - 40, height - 40));

                        // Save the image
                        image.Save();
                    }
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
 * 1. When a developer needs to generate multiple BMP files with identical styled borders quickly, they can reuse a single Pen instance to draw rectangles across all images.
 * 2. When automating the creation of thumbnail placeholders for a web gallery, the code can batch‑process BMP images using a shared Pen to ensure consistent border thickness and color.
 * 3. When producing printable reports that require a series of page‑size BMP diagrams with the same frame, reusing the Pen reduces object allocation and speeds up the C# image processing loop.
 * 4. When integrating Aspose.Imaging into a server‑side service that streams BMP images directly to disk, the shared Pen allows efficient drawing of shapes without recreating pen resources for each request.
 * 5. When building a desktop utility that converts a list of dimensions into bordered BMP samples for UI designers, the code demonstrates how to reuse a Pen while handling file streams and graphics clearing in .NET.
 */