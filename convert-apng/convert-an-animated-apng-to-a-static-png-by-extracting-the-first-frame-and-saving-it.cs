using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.png";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated APNG
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                if (image is ApngImage apngImage && apngImage.PageCount > 0)
                {
                    // Get the first frame
                    Image firstFrame = (Image)apngImage.Pages[0];

                    // Save the first frame as a static PNG
                    firstFrame.Save(outputPath, new PngOptions());
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not an APNG or contains no frames.");
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
 * 1. When a web developer needs to generate a thumbnail for an animated APNG file to display in a product catalog, they can extract the first frame and save it as a static PNG using Aspose.Imaging for .NET.
 * 2. When an e‑learning platform wants to replace animated APNG icons with non‑animated PNG placeholders for email notifications, the code can load the APNG, grab the first frame, and output a PNG image.
 * 3. When a mobile app needs to reduce file size by converting user‑uploaded animated APNGs to a single PNG preview before uploading to a server, the C# snippet performs the conversion efficiently.
 * 4. When a content management system must generate a fallback PNG for browsers that do not support APNG, developers can use this code to extract the initial frame and save it as a static PNG.
 * 5. When an automated image processing pipeline requires extracting the first frame of an APNG to use as a cover image for a video or slideshow, the Aspose.Imaging API can load the APNG and save the frame as a PNG.
 */