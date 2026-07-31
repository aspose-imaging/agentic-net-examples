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

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a FileStream for the output BMP file
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Configure BmpOptions with the stream as the source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(stream);

                // Create a 400x400 BMP image bound to the stream
                using (Image image = Image.Create(bmpOptions, 400, 400))
                {
                    // Obtain a Graphics object to draw on the image
                    Graphics graphics = new Graphics(image);

                    // Fill the entire canvas with yellow color
                    graphics.Clear(Color.Yellow);

                    // Save the image (writes to the bound stream)
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
 * 1. When a developer needs to generate a 400 × 400 BMP thumbnail filled with a solid yellow background for a Windows desktop application's splash screen, they can use BmpOptions with a FileStream source as shown.
 * 2. When an automated reporting tool must create a yellow placeholder BMP image of exact dimensions to embed in PDF reports, the code demonstrates how to write the image directly to a stream.
 * 3. When a server‑side C# service has to produce a BMP file on the fly for a legacy system that only accepts BMP format, using Aspose.Imaging’s BmpOptions and StreamSource ensures the image is saved without intermediate files.
 * 4. When a batch image‑processing script needs to initialize a blank yellow canvas of 400 × 400 pixels before overlaying vector graphics, the example shows how to create and clear the canvas via Graphics.Clear.
 * 5. When a unit test must verify that BMP output is correctly written to a file stream with the expected dimensions and background color, this code provides a reproducible way to generate the test image.
 */