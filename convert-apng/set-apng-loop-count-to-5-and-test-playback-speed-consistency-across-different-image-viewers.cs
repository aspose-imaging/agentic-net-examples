// HOW-TO: Create APNG With Loop Count 5 And Fixed Frame Delay In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\animation.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    NumPlays = 5,
                    DefaultFrameTime = 100
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, source.Width, source.Height))
                {
                    int frameCount = 5;
                    for (int i = 0; i < frameCount; i++)
                    {
                        apng.AddFrame(source);
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
 * 1. When you need to generate an animated PNG that repeats exactly five times for use in web banners or UI animations.
 * 2. When you want to ensure consistent playback speed across different image viewers by setting a uniform frame delay of 100 ms.
 * 3. When you are building a C# application that converts a static PNG into a looping APNG for mobile game sprites.
 * 4. When you must create an APNG with a predefined number of loops to comply with platform guidelines that limit animation repetitions.
 * 5. When you are testing how various browsers and image viewers handle APNG loop counts and frame timing using Aspose.Imaging for .NET.
 */
