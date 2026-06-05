using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/animation.webp";
            string outputDirectory = "Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the WebP image
            using (Image image = Image.Load(inputPath))
            {
                WebPImage webp = image as WebPImage;
                if (webp == null)
                {
                    Console.Error.WriteLine("The input file is not a WebP image.");
                    return;
                }

                int frameCount = webp.PageCount;

                // Extract each frame and save as BMP
                for (int i = 0; i < frameCount; i++)
                {
                    RasterImage frame = (RasterImage)webp.Pages[i];
                    string bmpPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        frame.Save(bmpPath, bmpOptions);
                    }
                }

                // Create GIF animation from the saved BMP frames
                string firstBmpPath = Path.Combine(outputDirectory, "frame_0.bmp");
                using (RasterImage firstRaster = (RasterImage)Image.Load(firstBmpPath))
                {
                    using (GifFrameBlock firstBlock = new GifFrameBlock(firstRaster))
                    {
                        using (GifImage gif = new GifImage(firstBlock))
                        {
                            // Add remaining frames
                            for (int i = 1; i < frameCount; i++)
                            {
                                string bmpPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");
                                using (RasterImage raster = (RasterImage)Image.Load(bmpPath))
                                {
                                    gif.AddPage(raster);
                                }
                            }

                            // Save the GIF animation
                            string gifPath = Path.Combine(outputDirectory, "animation.gif");
                            Directory.CreateDirectory(Path.GetDirectoryName(gifPath));
                            using (GifOptions gifOptions = new GifOptions())
                            {
                                gif.Save(gifPath, gifOptions);
                            }
                        }
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
 * 1. When a developer needs to convert an animated WebP advertisement into a GIF for email marketing platforms that only support GIF animations.
 * 2. When a legacy Windows application requires BMP frames from a WebP animation to perform per‑frame processing before re‑assembling into a GIF for UI playback.
 * 3. When a game developer wants to extract individual frames from a WebP sprite animation, edit them as BMP files, and then generate a GIF preview for designers.
 * 4. When a content management system stores uploaded WebP animations but must deliver GIF versions to browsers that lack WebP support, using Aspose.Imaging to automate the conversion.
 * 5. When a data‑analytics pipeline extracts frame‑by‑frame visual data from a WebP animation, saves them as BMP for pixel‑level analysis, and then creates a GIF summary for reporting.
 */