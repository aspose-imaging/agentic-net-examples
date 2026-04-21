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
            // Output file path
            string outputPath = "output.webp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create source bound to the output file
            Source source = new FileCreateSource(outputPath, false);

            // Default WebP options with the source
            using (WebPOptions options = new WebPOptions() { Source = source })
            {
                // Create a blank WebP image of 800x600 bound to the source
                using (RasterImage canvas = (RasterImage)Image.Create(options, 800, 600))
                {
                    // Save the bound image
                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}