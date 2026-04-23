using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output file path
            string outputPath = "output/output.webp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create default WebP options
            WebPOptions options = new WebPOptions();

            // Create a new blank WebP image with the specified dimensions
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