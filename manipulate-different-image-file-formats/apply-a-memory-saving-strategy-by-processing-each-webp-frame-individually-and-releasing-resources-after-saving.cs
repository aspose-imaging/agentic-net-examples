using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input WebP file path
            string inputPath = "input.webp";

            // Directory where individual frames will be saved
            string outputDirectory = "frames";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the animated WebP image
            using (WebPImage webp = new WebPImage(inputPath))
            {
                int frameCount = webp.PageCount;

                // Process each frame separately
                for (int i = 0; i < frameCount; i++)
                {
                    // Extract the current frame as a raster image
                    using (RasterImage frame = (RasterImage)webp.Pages[i])
                    {
                        // Build output path for the current frame
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.png");

                        // Ensure the directory for this frame exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as a PNG image
                        frame.Save(outputPath, new PngOptions());
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
 * 1. When an application needs to extract each frame from an animated WebP file and save them as separate PNG images while minimizing memory usage.
 * 2. When a server‑side image processing service must convert animated WebP advertisements into individual PNG frames for further analysis without loading the entire animation into memory.
 * 3. When a desktop utility has to generate thumbnail previews for each frame of a WebP animation and must release resources after each save to avoid out‑of‑memory errors.
 * 4. When a batch‑processing script processes large collections of animated WebP assets and needs to store each frame as a lossless PNG for archival or editing purposes.
 * 5. When a game development pipeline requires converting animated WebP sprites into separate PNG frames for sprite sheet creation while ensuring each frame is disposed promptly.
 */