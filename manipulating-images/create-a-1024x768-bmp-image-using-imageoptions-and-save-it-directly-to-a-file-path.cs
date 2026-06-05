using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24, // 24‑bpp color
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 1024x768 BMP image and save it directly to the specified file
            using (Image image = Image.Create(bmpOptions, 1024, 768))
            {
                // No additional drawing needed; the image is saved as is
                image.Save(); // Saves to the path defined in bmpOptions.Source
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}