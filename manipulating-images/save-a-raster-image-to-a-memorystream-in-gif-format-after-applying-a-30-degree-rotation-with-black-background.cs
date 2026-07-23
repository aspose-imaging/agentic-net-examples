using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // MemoryStream to hold the GIF data
            using (MemoryStream stream = new MemoryStream())
            {
                // Options for saving as GIF
                GifOptions gifOptions = new GifOptions();
                gifOptions.Source = new StreamSource(stream);

                // Load the GIF image, rotate, and save to the stream
                using (GifImage gif = (GifImage)Image.Load(inputPath))
                {
                    // Rotate 30 degrees, resize proportionally, black background
                    gif.Rotate(30f, true, Color.Black);
                    gif.Save(stream, gifOptions);
                }

                // Reset stream position before writing to file
                stream.Position = 0;

                // Write the MemoryStream content to the output file
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    stream.WriteTo(fileStream);
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
 * 1. When a web application needs to generate a rotated thumbnail of a user‑uploaded GIF for preview without writing intermediate files to disk.
 * 2. When an email service must embed a 30‑degree rotated animated GIF into the message body while keeping the image in memory for fast attachment.
 * 3. When a desktop utility creates a GIF‑based watermark overlay that requires rotating the source image and storing it in a MemoryStream before saving to a user‑specified folder.
 * 4. When a cloud function processes uploaded GIFs, applies a 30° rotation with a black background, and streams the result directly to a storage API without temporary files.
 * 5. When a game engine loads a sprite sheet GIF, rotates each frame, and writes the transformed GIF to a MemoryStream for immediate use in texture streaming.
 */