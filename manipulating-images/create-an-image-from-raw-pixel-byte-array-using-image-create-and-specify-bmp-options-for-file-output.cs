using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 100;
            int height = 100;

            // Raw pixel data (32‑bit ARGB). Fill the whole image with solid red.
            int[] pixels = new int[width * height];
            int red = unchecked((int)0xFFFF0000); // A=255, R=255, G=0, B=0
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = red;

            // BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24, // 24‑bpp BMP
                // Define where the image will be created
                Source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false)
            };

            // Create the image from the raw pixel array
            using (Image image = Image.Create(bmpOptions, width, height, pixels))
            {
                // Persist the image to disk
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}