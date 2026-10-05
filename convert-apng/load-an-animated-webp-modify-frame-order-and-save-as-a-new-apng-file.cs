// HOW-TO: Convert Animated WebP to APNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.webp";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                ApngOptions apngOptions = new ApngOptions();
                webp.Save(outputPath, apngOptions);
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
 * 1. When you need to display an animated image on platforms that support APNG but not WebP, you can convert the animated WebP to APNG with Aspose.Imaging in C#.
 * 2. When a mobile app requires an APNG asset for smooth animation while the source graphics are provided as animated WebP files, this code enables the conversion.
 * 3. When a web service processes user‑uploaded animated WebP files and must store them as APNG for compatibility with browsers that only support PNG animation, the snippet performs the transformation.
 * 4. When automating a build pipeline that generates animated assets, you can programmatically turn WebP sequences into APNG files using C# and Aspose.Imaging.
 * 5. When migrating an existing image library from WebP to APNG to meet licensing or performance guidelines, this example shows how to batch‑convert each animated WebP file.
 */
