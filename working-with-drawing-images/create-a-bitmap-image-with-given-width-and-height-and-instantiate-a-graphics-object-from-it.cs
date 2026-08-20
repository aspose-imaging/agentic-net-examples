// HOW-TO: Create BMP Image With Specified Dimensions Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            // Define image dimensions
            int width = 800;
            int height = 600;

            // Output file path (hardcoded)
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a FileCreateSource
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the bitmap image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Instantiate Graphics for the image
                Graphics graphics = new Graphics(image);

                // Optional: clear the canvas with a background color
                graphics.Clear(Color.White);

                // Save the image (no need to specify path again)
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
 * 1. When you need to generate a blank BMP canvas of a custom size for a reporting tool that later draws charts or text.
 * 2. When an application must create placeholder images on the fly for missing product photos, using a specific width and height.
 * 3. When a server‑side service prepares a BMP background to overlay watermarks or logos before sending it to clients.
 * 4. When you are automating the creation of bitmap files for unit tests that require a known image size and format.
 * 5. When you want to programmatically produce a white‑filled BMP file to serve as a template for further drawing operations in a C# graphics pipeline.
 */
