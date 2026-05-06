using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\output.webp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Default WebP options
            WebPOptions options = new WebPOptions();

            // Create a blank WebP image with dimensions 800x600
            using (WebPImage webPImage = new WebPImage(800, 600, options))
            {
                // Save the image using default options
                webPImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}