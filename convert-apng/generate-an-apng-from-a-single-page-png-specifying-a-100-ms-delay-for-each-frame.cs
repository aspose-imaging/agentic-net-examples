using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                const int frameDuration = 100; // milliseconds
                const int animationDuration = 1000; // total animation duration in milliseconds
                int numFrames = animationDuration / frameDuration;

                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = (uint)frameDuration,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
                {
                    apngImage.RemoveAllFrames();

                    for (int i = 0; i < numFrames; i++)
                    {
                        apngImage.AddFrame(sourceImage);
                    }

                    apngImage.Save();
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
 * 1. When a developer wants to create a looping animated icon for a desktop application by converting a static PNG logo into an APNG with a 100 ms frame delay.
 * 2. When a web developer needs to generate lightweight animated graphics for a website banner by duplicating a single PNG frame into an APNG sequence using C# and Aspose.Imaging.
 * 3. When an e‑learning platform programmatically produces animated step‑by‑step illustrations from a base PNG diagram, ensuring each frame displays for 100 ms in the resulting APNG file.
 * 4. When a game developer automates the creation of sprite animations from a single PNG asset, using Aspose.Imaging to build an APNG with consistent frame timing for UI elements.
 * 5. When a mobile app backend service converts uploaded PNG avatars into short looping APNG avatars with a 100 ms delay per frame for use in chat interfaces.
 */