// HOW-TO: Convert APNG to GIF with Frame Delays in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "animation.apng");
            string outputPath = Path.Combine("Output", "animation.gif");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                apng.Save(outputPath, new GifOptions());
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
 * 1. When you need to display an animated PNG on platforms that only support GIF, you can convert the APNG to a GIF while preserving the original frame timing.
 * 2. When creating email newsletters that require animated images, you can transform APNG assets into GIFs to ensure compatibility with most email clients.
 * 3. When building a web service that receives APNG uploads and returns GIFs for legacy browsers, this code provides a simple C# conversion routine.
 * 4. When generating thumbnail previews for an animation library that stores images as APNG, you can produce GIF previews that include the original frame delays.
 * 5. When integrating animated graphics into a Windows Forms application that only renders GIF animations, you can convert APNG files to GIFs with embedded delay information using Aspose.Imaging.
 */
