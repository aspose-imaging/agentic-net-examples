using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.apng";
            string outputDir = "frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                int frameCount = apng.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    using (Image frame = apng.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        frame.Save(outputPath, new PngOptions());
                    }
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
 * 1. When a developer needs to extract each frame from an animated APNG to individual PNG files for further image analysis or editing using C# and Aspose.Imaging.
 * 2. When a game developer wants to convert APNG sprite animations into separate PNG assets to integrate with a game engine that only supports static textures.
 * 3. When a web developer must generate thumbnail previews of each frame in an APNG for a media gallery, requiring per‑frame PNG extraction via Aspose.Imaging in .NET.
 * 4. When a data‑science team needs to feed individual animation frames into a machine‑learning model, they can use this code to split the APNG into PNG images for preprocessing.
 * 5. When a digital‑marketing analyst wants to repurpose frames from an animated APNG for social‑media posts, they can programmatically save each frame as a PNG using C# and Aspose.Imaging.
 */