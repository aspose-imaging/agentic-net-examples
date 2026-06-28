using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputPath = "input.webp";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the animated WebP image
            using (Image webpImage = Image.Load(inputPath))
            {
                // Cast to multipage interface to access frames
                var multipage = webpImage as Aspose.Imaging.IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("The input image does not contain animation frames.");
                    return;
                }

                // Create an APNG image with the same dimensions
                var createOptions = new ApngOptions();
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    webpImage.Width,
                    webpImage.Height))
                {
                    // Remove the default single frame
                    apngImage.RemoveAllFrames();

                    // Example reordering: reverse the frame order
                    for (int i = multipage.PageCount - 1; i >= 0; i--)
                    {
                        // Each page is a RasterImage; add it as a new frame
                        var frame = (RasterImage)multipage.Pages[i];
                        apngImage.AddFrame(frame);
                    }

                    // Save the reordered animation as APNG
                    apngImage.Save(outputPath, new ApngOptions());
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
 * 1. When a mobile app needs to convert an animated WebP sticker into an APNG for iOS compatibility while reversing the animation sequence.
 * 2. When a game developer wants to import a WebP sprite animation, flip the frame order for a reverse playback effect, and export it as an APNG to use in a Unity UI.
 * 3. When an e‑learning platform must transform user‑uploaded animated WebP tutorials into APNG files with reversed steps for a “rewind” demonstration.
 * 4. When a marketing automation script has to batch‑process animated WebP banners, reorder the frames to create a looping reverse animation, and save them as APNGs for email newsletters.
 * 5. When a digital archivist needs to preserve animated WebP assets by converting them to the lossless APNG format and adjusting the frame order to match the original timeline.
 */