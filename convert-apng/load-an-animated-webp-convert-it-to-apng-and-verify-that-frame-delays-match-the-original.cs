// HOW-TO: Convert Animated WebP to APNG and Preserve Frame Delays in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "animated.webp");
            string outputPath = Path.Combine("Output", "converted.apng");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                img.Save(outputPath, new ApngOptions());
            }

            Console.WriteLine("Conversion successful.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display animated images on platforms that support APNG but not WebP, you can convert the WebP animation to APNG using C#.
 * 2. When optimizing a web application’s assets, you may convert animated WebP files to APNG to ensure compatibility with browsers that only support PNG animation.
 * 3. When creating a cross‑platform mobile app, you might convert animated WebP assets to APNG so iOS can render the animation correctly.
 * 4. When processing user‑uploaded animated WebP files on a server, you can convert them to APNG to store them in a format that preserves frame timing for later playback.
 * 5. When building an image‑processing pipeline that generates reports, you may need to convert animated WebP to APNG while keeping the original frame delays intact for accurate animation timing.
 */
