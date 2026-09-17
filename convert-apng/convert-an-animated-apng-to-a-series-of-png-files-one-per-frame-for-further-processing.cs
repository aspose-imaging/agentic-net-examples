// HOW-TO: Extract Frames from Animated APNG to PNG Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputFolder = "frames";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputFolder);

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                if (image is Aspose.Imaging.IMultipageImage multipage)
                {
                    int frameCount = multipage.PageCount;
                    for (int i = 0; i < frameCount; i++)
                    {
                        using (Aspose.Imaging.Image frame = (Aspose.Imaging.Image)multipage.Pages[i])
                        {
                            string outputPath = Path.Combine(outputFolder, $"frame_{i}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            PngOptions options = new PngOptions();
                            frame.Save(outputPath, options);
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
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
 * 1. When you need to break down an animated APNG into individual PNG frames for further editing or analysis in a .NET application.
 * 2. When you want to generate thumbnail images for each frame of an APNG to display in a gallery or UI.
 * 3. When you are building a video‑to‑image pipeline and must extract each animation frame as a separate PNG for downstream processing.
 * 4. When you need to compare or process specific frames of an APNG using image‑processing libraries that only support single‑page PNGs.
 * 5. When you are creating a sprite sheet or frame‑by‑frame animation in a game engine and require each APNG frame saved as an individual PNG file.
 */
