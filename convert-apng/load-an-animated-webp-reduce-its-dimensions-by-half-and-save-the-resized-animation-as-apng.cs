// HOW-TO: Resize Animated WebP to Half Size and Save as APNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                int newWidth = webp.Width / 2;
                int newHeight = webp.Height / 2;
                webp.Resize(newWidth, newHeight);

                ApngOptions options = new ApngOptions();
                webp.Save(outputPath, options);
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
 * 1. When you need to display a smaller version of an animated WebP on a mobile website, you can resize it and convert it to APNG for broader browser compatibility.
 * 2. When an e‑learning platform requires animated illustrations in APNG format but only has source assets as animated WebP, this code halves the dimensions and performs the conversion.
 * 3. When optimizing email newsletters that support APNG but not WebP, you can shrink the animation to reduce file size and save it as APNG using C#.
 * 4. When a game UI needs low‑resolution animated icons, you can programmatically resize the original WebP animation and export it as APNG for use in the engine.
 * 5. When a content‑management system automatically processes uploaded animated WebP files, this snippet can generate a half‑size APNG thumbnail for preview purposes.
 */
