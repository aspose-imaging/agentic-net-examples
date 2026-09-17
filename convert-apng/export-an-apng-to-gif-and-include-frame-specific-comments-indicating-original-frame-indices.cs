// HOW-TO: Convert Animated PNG to GIF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                var gifOptions = new GifOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                apng.Save(outputPath, gifOptions);
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
 * 1. When you need to display an animated PNG on platforms that only support GIF, you can convert it to GIF with Aspose.Imaging in C#.
 * 2. When a web application must generate lightweight animated images for email newsletters, converting APNG to GIF reduces file size and ensures compatibility.
 * 3. When processing user‑uploaded APNG files on a server and storing them as GIFs for a legacy content management system, this code automates the conversion.
 * 4. When creating a batch job that transforms a library of APNG assets into GIFs for use in mobile apps that lack APNG support, the example provides the necessary steps.
 * 5. When integrating image conversion into a .NET service that prepares animated images for archival, you can start with this APNG‑to‑GIF conversion as the base operation.
 */
