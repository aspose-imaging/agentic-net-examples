using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputPath = "output.apng";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image
            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                // Cast to multipage interface to access frames
                IMultipageImage multipage = webp as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("The WebP image does not contain any frames.");
                    return;
                }

                // Extract frames as RasterImage objects
                List<RasterImage> frames = new List<RasterImage>();
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Each page is a RasterImage in WebPImage
                    frames.Add((RasterImage)multipage.Pages[i]);
                }

                // Reorder frames (example: reverse order)
                List<RasterImage> reorderedFrames = frames.AsEnumerable().Reverse().ToList();

                // Prepare APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 100 // default duration in ms
                };

                // Use dimensions of the first frame for the canvas
                int width = reorderedFrames[0].Width;
                int height = reorderedFrames[0].Height;

                // Create APNG image bound to the output file
                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    // Remove the default single frame
                    apng.RemoveAllFrames();

                    // Add frames in the new order
                    foreach (RasterImage frame in reorderedFrames)
                    {
                        apng.AddFrame(frame);
                    }

                    // Save the APNG (output path is already bound via FileCreateSource)
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
 * 1. When a mobile app needs to convert user‑generated animated WebP stickers into APNG format while reversing the animation sequence for a special effect, developers can use this C# code with Aspose.Imaging.
 * 2. When an e‑learning platform wants to reorder frames of an animated WebP tutorial diagram and export it as an APNG to ensure compatibility with browsers that only support PNG animation, the code provides a straightforward solution.
 * 3. When a game developer must generate custom achievement badges by loading an animated WebP sprite sheet, swapping the frame order, and saving it as an APNG for use in Unity, this snippet handles the conversion.
 * 4. When a digital marketing tool needs to take an animated WebP advertisement, reverse its playback direction, and output an APNG for email campaigns that require PNG animation, the example demonstrates the required steps in C#.
 * 5. When a content management system processes uploaded animated WebP assets, rearranges their frames to match a predefined timeline, and stores them as APNG files for archival, this Aspose.Imaging code automates the workflow.
 */