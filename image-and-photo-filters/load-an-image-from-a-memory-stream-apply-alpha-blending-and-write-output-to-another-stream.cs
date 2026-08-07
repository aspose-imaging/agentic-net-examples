using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string backgroundPath = "background.jpg";
            string overlayPath = "overlay.png";
            string outputPath = "output.png";

            // Validate input files
            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load background image into a memory stream
            using (FileStream bgFileStream = File.OpenRead(backgroundPath))
            using (MemoryStream bgMemoryStream = new MemoryStream())
            {
                bgFileStream.CopyTo(bgMemoryStream);
                bgMemoryStream.Position = 0;

                // Load overlay image into a memory stream
                using (FileStream ovFileStream = File.OpenRead(overlayPath))
                using (MemoryStream ovMemoryStream = new MemoryStream())
                {
                    ovFileStream.CopyTo(ovMemoryStream);
                    ovMemoryStream.Position = 0;

                    // Load images from streams
                    using (RasterImage background = (RasterImage)Image.Load(bgMemoryStream))
                    using (RasterImage overlay = (RasterImage)Image.Load(ovMemoryStream))
                    {
                        // Apply alpha blending (50% opacity)
                        background.Blend(new Point(0, 0), overlay, 128);

                        // Save blended image to output stream
                        using (MemoryStream outputMemoryStream = new MemoryStream())
                        {
                            PngOptions pngOptions = new PngOptions();
                            background.Save(outputMemoryStream, pngOptions);
                            outputMemoryStream.Position = 0;

                            // Write output stream to file
                            using (FileStream outFileStream = new FileStream(outputPath, FileMode.Create))
                            {
                                outputMemoryStream.CopyTo(outFileStream);
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
 * 1. When a web application needs to dynamically watermark a JPEG photo with a semi‑transparent PNG logo before sending it to the client, developers can load both images into memory streams, blend them with 50 % opacity, and stream the result back.
 * 2. When generating product thumbnails that combine a base image with a promotional overlay (e.g., “Sale” badge) on the fly, the code lets you read the files into MemoryStream, apply alpha blending, and write the composited PNG to a response stream.
 * 3. When an email service creates personalized newsletters and must embed a background picture with a translucent banner image, this approach uses Aspose.Imaging to blend the PNG overlay onto the JPEG background entirely in memory without temporary files.
 * 4. When a desktop utility merges a user‑selected foreground PNG onto a scanned JPEG document, the developer can load both files into streams, blend them at 50 % opacity, and save the combined image to another stream for further processing.
 * 5. When a cloud function processes uploaded images to add a semi‑transparent frame or border stored as a PNG overlay, the snippet demonstrates how to read the source and overlay from streams, perform alpha blending, and output the final PNG to a storage stream.
 */