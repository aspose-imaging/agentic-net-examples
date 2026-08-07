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
            using (MemoryStream ms = new MemoryStream())
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(ms);

                int width = 200;
                int height = 200;

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.DrawRectangle(new Pen(Color.Green, 2), new Rectangle(20, 20, 100, 50));
                    image.Save();
                }

                // Example of writing the stream to a file (optional)
                // string outputPath = "output.bmp";
                // Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                // File.WriteAllBytes(outputPath, ms.ToArray());
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
 * 1. When a developer needs to generate a BMP thumbnail with a highlighted area on the fly and send it directly over a network without creating a temporary file, they can use a MemoryStream with Aspose.Imaging to draw a green rectangle and stream the image.
 * 2. When building a web API that returns a dynamically created BMP diagram (e.g., a simple UI mock‑up) as a byte array, the code creates the image in memory, draws a green rectangle, and writes it to the response stream.
 * 3. When implementing a document conversion service that embeds a visual marker into BMP pages before packaging them, the developer can draw a green rectangle using Aspose.Imaging’s Graphics object and keep the result in a MemoryStream for further processing.
 * 4. When creating unit tests for image‑processing pipelines that require a known BMP input with a specific shape, this snippet quickly generates the test image in memory without touching the file system.
 * 5. When developing a desktop application that needs to preview a BMP with a selection box before saving, the code draws the green rectangle on a MemoryStream‑based image, allowing the preview to be displayed instantly.
 */