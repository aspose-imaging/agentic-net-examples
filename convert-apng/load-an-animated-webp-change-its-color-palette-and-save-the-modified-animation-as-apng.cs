// HOW-TO: Convert Animated WebP to APNG with Color Inversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\animation.webp";
            string outputPath = "Output\\modified.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, webp.Width, webp.Height))
                {
                    foreach (RasterImage frame in webp.Pages)
                    {
                        Rectangle rect = new Rectangle(0, 0, frame.Width, frame.Height);
                        int[] pixels = frame.LoadArgb32Pixels(rect);
                        for (int i = 0; i < pixels.Length; i++)
                        {
                            int argb = pixels[i];
                            int a = (argb >> 24) & 0xFF;
                            int r = (argb >> 16) & 0xFF;
                            int g = (argb >> 8) & 0xFF;
                            int b = argb & 0xFF;
                            r = 255 - r;
                            g = 255 - g;
                            b = 255 - b;
                            pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                        }
                        frame.SaveArgb32Pixels(rect, pixels);
                        apng.AddFrame(frame);
                    }
                    apng.Save();
                }
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
 * 1. When you need to display a WebP animation on platforms that only support APNG, you can convert the animated WebP to an APNG while applying a color inversion to match a dark theme.
 * 2. When creating a visual effect that requires the original colors of an animated WebP to be reversed for a night‑mode UI, this code loads each frame, inverts its palette, and saves the result as an APNG.
 * 3. When a game engine accepts APNG sprites but your assets are delivered as animated WebP files, you can batch‑process them to APNG with modified colors using Aspose.Imaging in C#.
 * 4. When generating marketing GIF‑like animations for email newsletters that need transparent background and custom color styling, you can transform animated WebP files into APNG with inverted colors.
 * 5. When automating a CI pipeline that validates image assets, you might need to convert animated WebP assets to APNG and apply a color shift to ensure they meet branding guidelines.
 */
