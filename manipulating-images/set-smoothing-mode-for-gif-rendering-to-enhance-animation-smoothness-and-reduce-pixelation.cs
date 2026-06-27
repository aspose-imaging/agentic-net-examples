using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

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
                GifImage gif = (GifImage)image;
                // Apply bilateral smoothing filter to the entire GIF to enhance smoothness
                gif.Filter(gif.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5));
                gif.Save(outputPath);
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
 * 1. When a developer needs to reduce pixelation in a GIF animation for a web banner by applying a bilateral smoothing filter using Aspose.Imaging for .NET.
 * 2. When a developer wants to improve the visual quality of user‑generated GIFs in a social media app by smoothing frame transitions before saving the file.
 * 3. When a developer is building an e‑learning platform and must ensure that instructional GIFs play smoothly on low‑resolution displays by applying smoothing mode.
 * 4. When a developer integrates GIF processing into a desktop publishing tool and needs to automatically enhance animation smoothness for printed materials.
 * 5. When a developer creates an automated batch job that cleans up legacy GIF assets, applying a smoothing filter to each file to modernize their appearance.
 */