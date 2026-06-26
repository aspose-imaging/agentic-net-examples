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
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100,
                    ColorType = PngColorType.TruecolorWithAlpha,
                    NumPlays = 0 // infinite looping
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    apngImage.RemoveAllFrames();

                    int totalFrames = 5;
                    for (int i = 0; i < totalFrames; i++)
                    {
                        apngImage.AddFrame(sourceImage);
                        ApngFrame frame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                        frame.FrameTime = (int)(100 + i * 50); // custom delay per frame
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
 * 1. When a developer wants to generate an animated APNG from a single PNG logo to display a loading spinner with gradually increasing frame delays on a web dashboard.
 * 2. When an e‑learning platform needs to create step‑by‑step tutorial animations by duplicating a base PNG and assigning custom frame times to highlight each instruction.
 * 3. When a mobile game developer wants to produce a looping character idle animation by reusing a high‑resolution PNG sprite and setting different frame delays for smoother motion.
 * 4. When a marketing team requires a promotional banner that cycles through the same product image with varying pause durations, using C# and Aspose.Imaging to output an APNG file.
 * 5. When an IoT device UI must show a status indicator that repeats indefinitely, and the developer uses the code to convert a PNG status icon into an APNG with infinite looping and per‑frame timing control.
 */