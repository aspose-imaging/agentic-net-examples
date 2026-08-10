// HOW-TO: Extract Frames from Animated GIF and Save as PNG Sequence in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input GIF and output folder paths
        string inputPath = "Animation.gif";
        string outputFolder = "ExtractedFrames";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output folder exists
            Directory.CreateDirectory(outputFolder);

            // Load the animated GIF
            using (Image img = Image.Load(inputPath))
            {
                // Cast to GifImage to access frames
                GifImage gif = img as GifImage;
                if (gif == null)
                {
                    Console.Error.WriteLine("The provided file is not a GIF image.");
                    return;
                }

                // Iterate through each frame (page) in the GIF
                for (int i = 0; i < gif.PageCount; i++)
                {
                    // Retrieve the frame as a RasterImage
                    using (RasterImage frame = (RasterImage)gif.Pages[i])
                    {
                        // Build output file path (e.g., frame_000.png)
                        string outputPath = Path.Combine(outputFolder, $"frame_{i:D3}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as PNG
                        var pngOptions = new PngOptions();
                        frame.Save(outputPath, pngOptions);
                    }
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
 * 1. When you need to break down an animated GIF into individual PNG images for creating thumbnails or preview frames in a web gallery.
 * 2. When a video editing tool requires each frame of a GIF animation to be processed separately as PNG files for further compositing.
 * 3. When you want to generate a sprite sheet by extracting GIF frames and then recombining the PNG sequence in a game development pipeline.
 * 4. When an e‑learning platform must convert animated GIF lessons into static PNG slides for accessibility or printing purposes.
 * 5. When a digital asset management system needs to index each frame of an animated GIF as separate PNG files for searchable metadata tagging.
 */
