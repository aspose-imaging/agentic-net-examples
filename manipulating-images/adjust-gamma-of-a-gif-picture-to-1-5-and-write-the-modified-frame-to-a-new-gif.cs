// HOW-TO: Adjust Gamma of GIF Image to 1.5 and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.AdjustGamma(1.5f);
                GifOptions options = new GifOptions();
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
 * 1. When you need to brighten a GIF animation for web display by increasing its gamma without losing frame data.
 * 2. When a marketing tool must automatically enhance the contrast of user‑uploaded GIFs before embedding them in emails.
 * 3. When a game developer wants to apply a consistent gamma boost to sprite sheets stored as GIF files during the asset pipeline.
 * 4. When an e‑learning platform processes animated GIF tutorials and requires gamma adjustment to improve readability on low‑light screens.
 * 5. When a batch‑processing script must correct the gamma of multiple GIF files and save the results as new GIFs using Aspose.Imaging in C#.
 */
