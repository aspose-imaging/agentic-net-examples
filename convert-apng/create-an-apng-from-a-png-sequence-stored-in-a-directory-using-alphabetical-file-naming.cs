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
            // Hardcoded input PNG file paths (alphabetical order)
            string inputPath1 = "frames\\frame1.png";
            string inputPath2 = "frames\\frame2.png";
            string inputPath3 = "frames\\frame3.png";

            // Verify each input file exists
            if (!File.Exists(inputPath1)) { Console.Error.WriteLine($"File not found: {inputPath1}"); return; }
            if (!File.Exists(inputPath2)) { Console.Error.WriteLine($"File not found: {inputPath2}"); return; }
            if (!File.Exists(inputPath3)) { Console.Error.WriteLine($"File not found: {inputPath3}"); return; }

            // Hardcoded output APNG path
            string outputPath = "output\\animation.apng";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first image to obtain canvas dimensions
            using (RasterImage firstImage = (RasterImage)Image.Load(inputPath1))
            {
                // Configure APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // default frame duration in milliseconds
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG canvas bound to the output file
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, firstImage.Width, firstImage.Height))
                {
                    // Remove the automatically added initial frame
                    apngImage.RemoveAllFrames();

                    // Add the first frame
                    apngImage.AddFrame(firstImage);

                    // Load and add subsequent frames
                    using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
                    {
                        apngImage.AddFrame(img2);
                    }

                    using (RasterImage img3 = (RasterImage)Image.Load(inputPath3))
                    {
                        apngImage.AddFrame(img3);
                    }

                    // Save the APNG (output path already bound via Source)
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
 * 1. When a developer needs to generate an animated PNG (APNG) for a web banner from a series of sequentially named PNG frames stored in a folder.
 * 2. When an e‑learning platform wants to convert step‑by‑step tutorial screenshots (frame1.png, frame2.png, …) into a single APNG file for smoother playback in browsers.
 * 3. When a game developer creates sprite animations offline by assembling PNG sprite sheets into an APNG to preview character motions without writing custom rendering code.
 * 4. When a marketing team automates the production of product showcase animations by combining product photo PNGs into an APNG that can be embedded in email newsletters.
 * 5. When a mobile app generates lightweight animated icons by merging PNG assets into an APNG at runtime using C# and Aspose.Imaging.
 */