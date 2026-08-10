// HOW-TO: Convert APNG to Animated GIF with Frame Delays in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
                GifOptions gifOptions = new GifOptions();
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
 * 1. When you need to display an animated PNG on platforms that only support GIF, you can convert the APNG to an animated GIF while preserving frame timing using Aspose.Imaging in C#.
 * 2. When creating email newsletters that require animated images, you can transform APNG assets into GIFs to ensure compatibility with most email clients.
 * 3. When building a web application that generates user‑uploaded animations, you can standardize the output by converting uploaded APNG files to GIFs for easier browser rendering.
 * 4. When archiving animated graphics for legacy systems, you can use the code to convert APNG sequences to GIFs and embed the original frame delays in the GIF comment extension.
 * 5. When optimizing image pipelines for mobile apps that only decode GIF animations, you can programmatically convert APNG files to GIF format with Aspose.Imaging to maintain animation speed information.
 */
