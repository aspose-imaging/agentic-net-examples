using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input PNG files and output APNG path
            string[] inputPaths = { "frame1.png", "frame2.png", "frame3.png", "frame4.png" };
            string outputPath = "output_animation.png";

            // Verify each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first image to obtain dimensions
            using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
            {
                // Create APNG options with bound output source
                Source outputSource = new FileCreateSource(outputPath, false);
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = outputSource,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, firstImage.Width, firstImage.Height))
                {
                    // Remove the default empty frame
                    apngImage.RemoveAllFrames();

                    Random rnd = new Random();

                    // Add each PNG as a frame with a random delay between 50 and 150 ms
                    foreach (string path in inputPaths)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(path))
                        {
                            int delayMs = rnd.Next(50, 151); // 50 to 150 inclusive
                            apngImage.AddFrame(frame, (uint)delayMs);
                        }
                    }

                    // Save the bound APNG image
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