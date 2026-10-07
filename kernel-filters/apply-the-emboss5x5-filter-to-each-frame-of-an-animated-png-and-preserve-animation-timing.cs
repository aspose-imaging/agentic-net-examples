// HOW-TO: Apply Emboss 5x5 Filter to Animated PNG Frames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image loadedImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)loadedImage;

                for (int i = 0; i < apng.PageCount; i++)
                {
                    var frame = (Aspose.Imaging.RasterImage)apng.Pages[i];
                    frame.Filter(frame.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));
                }

                apng.Save(outputPath);
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
 * 1. When you need to add a stylized emboss effect to every frame of an APNG used in a game UI while preserving the original animation timing.
 * 2. When you want to batch‑process an animated PNG to give it a 3‑D look without altering the frame delays in a .NET application.
 * 3. When generating website animations from an APNG and require a consistent emboss filter across all frames while keeping the animation playback speed.
 * 4. When you have an existing animated PNG and must apply a convolution filter to each raster image directly, avoiding manual extraction and re‑assembly of frames.
 * 5. When creating custom avatar or badge animations on a server‑side service and need to apply the Emboss5x5 filter to each frame using Aspose.Imaging for .NET.
 */
