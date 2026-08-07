using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        const string inputPath = "input.svg";
        const string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a brand logo stored as an SVG into an animated APNG with a pulsing color gradient for use in web banners.
 * 2. When a mobile app requires lightweight animated icons, and the developer uses Aspose.Imaging for .NET to load the SVG, apply a dynamic fill gradient, and export it as an APNG to reduce file size.
 * 3. When an e‑learning platform wants to display step‑by‑step illustrations with changing colors, the developer loads the vector SVG, animates the fill gradient, and saves the result as an APNG for seamless playback.
 * 4. When a game UI designer wants to create animated health‑bar graphics from SVG assets, the developer uses C# and Aspose.Imaging to animate the fill color gradient and generate an APNG sprite sheet.
 * 5. When a marketing email needs an eye‑catching animated illustration that works across email clients, the developer converts the SVG to an APNG with a looping gradient animation using Aspose.Imaging for .NET.
 */