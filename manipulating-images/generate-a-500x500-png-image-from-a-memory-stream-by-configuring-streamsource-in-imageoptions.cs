// HOW-TO: Create 500x500 PNG from MemoryStream Using Aspose Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions
                {
                    Source = new StreamSource(memoryStream)
                };

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.Wheat);
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a blank placeholder PNG of a specific size directly from a memory stream for dynamic web content.
 * 2. When you want to create a custom-sized image in memory before saving it to disk in a server‑side C# application.
 * 3. When you are building a PDF or report generator that requires a 500×500 PNG thumbnail created on the fly without reading from a file.
 * 4. When you need to programmatically set the image source to a StreamSource to avoid temporary files during image processing pipelines.
 * 5. When you are developing a cloud service that must produce PNG assets from streamed data for downstream image manipulation or storage.
 */
