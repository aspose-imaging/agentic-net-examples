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
            // Output file path (relative)
            string outputPath = "Output/output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream that the image will write to
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
            {
                // Configure PNG options to use the stream as the source
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(fileStream);

                // Create a 500x500 PNG image bound to the stream
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Optional: clear the canvas with a background color
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.Wheat);

                    // Save the image (writes to the stream)
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
 * 1. When a developer needs to generate a 500x500 PNG thumbnail on the fly and write it directly to a file stream using Aspose.Imaging’s StreamSource to avoid intermediate bitmap objects.
 * 2. When an ASP.NET web application must create a placeholder PNG image in memory and stream it to the client as part of an HTTP response without first saving to disk.
 * 3. When a background service processes batch jobs that require creating blank PNG canvases for later overlay of graphics, using StreamSource to manage I/O efficiently.
 * 4. When a unit test validates image creation logic by writing a PNG image to a memory‑backed stream and then checking the resulting file for correctness.
 * 5. When integrating with a third‑party API that expects a PNG image supplied via a stream, and the developer needs to produce the image programmatically with Aspose.Imaging.
 */