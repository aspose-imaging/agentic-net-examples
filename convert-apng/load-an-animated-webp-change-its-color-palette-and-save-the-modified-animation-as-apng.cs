// HOW-TO: Convert Animated WebP to APNG with Custom Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    Palette = new ColorPalette(new Color[]
                    {
                        Color.Red,
                        Color.Green,
                        Color.Blue
                    })
                };

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
 * 1. When you need to display an animated image on a platform that only supports APNG, you can convert an animated WebP to APNG while applying a limited color palette for smaller file size.
 * 2. When creating a game asset pipeline that requires all sprites to use a specific three‑color palette, you can load animated WebP frames, replace their colors, and export them as APNG for consistent rendering.
 * 3. When optimizing email newsletters that allow animated PNGs but not WebP, you can transform the WebP animation into an APNG with a custom palette to meet the format restrictions and branding colors.
 * 4. When building a cross‑platform UI library that needs a unified animation format, you can programmatically convert user‑provided WebP animations to APNG and enforce a predefined palette to ensure visual consistency.
 * 5. When generating lightweight animated icons for a web dashboard, you can take an existing animated WebP, limit its colors to red, green, and blue, and save it as an APNG to reduce bandwidth while preserving animation.
 */
