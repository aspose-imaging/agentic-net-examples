using System;
using System.IO;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output_dithered.gif";

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

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                GifImage gifImage = (GifImage)image;

                for (int i = 0; i < gifImage.PageCount; i++)
                {
                    gifImage.ActiveFrame = (GifFrameBlock)gifImage.Pages[i];
                    gifImage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1, null);
                }

                GifOptions gifOptions = new GifOptions();
                gifImage.Save(outputPath, gifOptions);
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
 * 1. When creating an animated GIF from a series of low‑color screenshots, a developer can dither each frame with Floyd‑Steinberg to add texture and reduce banding before saving the final GIF.
 * 2. When converting a high‑resolution video clip into a small animated GIF for web use, applying per‑frame dithering ensures the limited 256‑color palette still preserves visual detail.
 * 3. When generating GIF‑based data visualizations (e.g., heat‑map animations) that need a smoother gradient, a developer can dither each frame to improve perceived color depth.
 * 4. When building an e‑learning module that displays step‑by‑step diagrams as an animated GIF, dithering each frame helps maintain readability on devices with limited color support.
 * 5. When optimizing legacy GIF assets for modern browsers, a developer can load the original GIF, dither each frame, and re‑save it to achieve a more polished texture without increasing file size.
 */