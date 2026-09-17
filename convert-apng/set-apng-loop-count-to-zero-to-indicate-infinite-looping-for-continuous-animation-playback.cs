// HOW-TO: Create Infinite Loop APNG From PNG In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.apng";
        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage source = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    NumPlays = 0
                };

                using (ApngImage apng = (ApngImage)Aspose.Imaging.Image.Create(options, source.Width, source.Height))
                {
                    apng.AddFrame(source);
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
 * 1. When you need to generate an animated PNG that repeats forever for a website banner using C# and Aspose.Imaging.
 * 2. When you want to convert a static PNG into an APNG with continuous playback for mobile game UI elements.
 * 3. When you are building a digital signage system that requires an endlessly looping animation without manually editing frame metadata.
 * 4. When you need to programmatically set the NumPlays property to zero to indicate infinite looping for an APNG created from existing raster images.
 * 5. When you automate the creation of looping APNG files for e‑learning tutorials that must play continuously across different browsers.
 */
