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
        string outputPath = @"c:\temp\output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions
            int width = 800;
            int height = 600;

            // Set up BMP options with a FileCreateSource bound to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Instantiate Graphics for drawing on the image
                Graphics graphics = new Graphics(image);

                // Optional: clear the canvas with a background color
                graphics.Clear(Color.LightGray);

                // Save the image (no path needed because the source is already bound)
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
 * 1. When a developer needs to generate a blank BMP canvas of a specific size to later draw custom graphics such as charts or watermarks in a C# desktop application.
 * 2. When an automated reporting tool must create a temporary bitmap image, clear it with a background color, and save it directly to disk without loading an existing file.
 * 3. When a server‑side service has to produce a fixed‑dimension image (e.g., 800×600) for thumbnail generation or placeholder graphics before adding dynamic content.
 * 4. When a batch‑processing script requires initializing a Graphics object on a newly created image file to programmatically render shapes, text, or logos using Aspose.Imaging for .NET.
 * 5. When a unit test needs to verify that image creation, canvas clearing, and file saving work correctly by creating a BMP file in a known folder with predetermined dimensions.
 */