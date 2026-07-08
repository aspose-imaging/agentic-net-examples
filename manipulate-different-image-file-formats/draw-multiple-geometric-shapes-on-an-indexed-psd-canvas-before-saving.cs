using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var options = new JpegOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to convert a user‑uploaded image to a standardized JPEG for web delivery while first confirming that the source file exists.
 * 2. When an automated batch job must read images from a source folder, create any missing output directories, and save the processed files using Aspose.Imaging’s JpegOptions.
 * 3. When a server‑side application has to validate the presence of an input image before performing any transformation to prevent runtime exceptions.
 * 4. When a desktop utility wants to re‑encode an image with specific JPEG compression settings and metadata control before storing it in a different location.
 * 5. When robust error handling and logging are required around image loading and saving operations to provide clear diagnostics in a C# .NET service.
 */