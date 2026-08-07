using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the bitmap image canvas
            using (Image image = Image.Create(bmpOptions, 500, 400))
            {
                // Instantiate Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a background color
                graphics.Clear(Color.Wheat);

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a blank BMP file of a specific size (e.g., 500×400 pixels) for a report or document and fill it with a solid background color using C# and Aspose.Imaging.
 * 2. When an application must programmatically create a 24‑bit bitmap thumbnail for a product catalog and requires a Graphics object to draw additional elements later.
 * 3. When a Windows service has to produce a temporary BMP canvas for batch image processing, ensuring the output directory exists and the file is saved via FileCreateSource.
 * 4. When a developer wants to initialize a bitmap canvas, clear it with a custom Color (such as Wheat), and save it as a BMP image without using System.Drawing, leveraging Aspose.Imaging’s Image and Graphics classes.
 * 5. When an automated testing framework needs to create a known‑size BMP image on the fly to verify image‑handling logic, using BmpOptions, Image.Create, and Graphics in a .NET environment.
 */