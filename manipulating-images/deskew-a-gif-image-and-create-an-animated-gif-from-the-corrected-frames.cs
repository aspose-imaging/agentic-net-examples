using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output\\deskewed.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Deskew each frame
                for (int i = 0; i < gif.PageCount; i++)
                {
                    RasterImage frame = (RasterImage)gif.Pages[i];
                    if (!frame.IsCached)
                    {
                        frame.CacheData();
                    }
                    // Normalize angle without resizing, fill background with white
                    frame.NormalizeAngle(false, Aspose.Imaging.Color.White);
                }

                // Save the corrected animated GIF
                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
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
 * 1. When processing scanned animated GIF receipts that are slightly tilted, a developer can use this code to deskew each frame and produce a straight‑aligned animated GIF for accurate OCR.
 * 2. When a web application needs to correct the orientation of user‑uploaded animated GIF memes before displaying them, this routine can normalize the angle of every frame and save the result as a new GIF.
 * 3. When generating product showcase animations from photographed items that were captured at an angle, the code can deskew each frame and output a clean animated GIF for e‑commerce sites.
 * 4. When archiving legacy animated GIF tutorials that have become skewed due to scanning, developers can apply this method to straighten the frames and preserve the original animation timing.
 * 5. When creating time‑lapse GIFs from a series of camera‑shot images that were not perfectly aligned, the program can automatically correct the tilt of each frame and assemble them into a seamless animated GIF.
 */