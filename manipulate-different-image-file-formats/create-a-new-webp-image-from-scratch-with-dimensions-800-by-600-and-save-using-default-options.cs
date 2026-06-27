using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = "C:\\temp\\output.webp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Default WebP options
            WebPOptions options = new WebPOptions();

            // Create a blank WebP image with the specified dimensions
            int width = 800;
            int height = 600;
            using (WebPImage webPImage = new WebPImage(width, height, options))
            {
                // Save the image to the specified path
                webPImage.Save(outputPath);
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
 * 1. When generating placeholder images for a web page layout, a developer can use this code to create an 800 × 600 WebP file with default compression settings.
 * 2. When a batch job needs to produce blank canvas files for later drawing operations, the snippet creates a WebP image of the required size using Aspose.Imaging in C#.
 * 3. When automating the creation of default thumbnails for a media library, this example quickly generates an 800 × 600 WebP image that can be filled with content later.
 * 4. When testing image upload pipelines that require a WebP file, the code provides a simple way to generate a compliant 800 × 600 image without external assets.
 * 5. When initializing a new project’s asset folder with sample WebP files, a developer can run this C# program to create an 800 × 600 image using the library’s default WebPOptions.
 */