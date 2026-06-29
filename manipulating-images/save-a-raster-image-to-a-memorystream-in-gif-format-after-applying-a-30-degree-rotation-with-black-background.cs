using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and dummy output paths
            string inputPath = "input.jpg";
            string outputPath = "output/output.gif";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (even though we save to a stream)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Rotate 30 degrees with black background, resizing proportionally
                image.Rotate(30f, true, Aspose.Imaging.Color.Black);

                // Prepare GIF save options
                using (GifOptions options = new GifOptions())
                {
                    options.BackgroundColor = Aspose.Imaging.Color.Black;

                    // Save to a memory stream in GIF format
                    using (MemoryStream stream = new MemoryStream())
                    {
                        image.Save(stream, options);
                        Console.WriteLine($"Image saved to memory stream. Length: {stream.Length} bytes.");
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
 * 1. When a web service needs to generate a thumbnail preview of a user‑uploaded JPEG, rotate it 30° for a stylized effect, and return the result as a GIF stream without writing to disk.
 * 2. When an email‑marketing platform creates animated GIF banners on the fly, applying a 30‑degree rotation with a black background to fit a design template and sending the image as a memory stream attachment.
 * 3. When a desktop application converts scanned photos to GIF for legacy printer compatibility, rotating each image 30° to correct orientation and using a MemoryStream to avoid temporary files.
 * 4. When a cloud function processes images for a mobile app, applying a 30° rotation with black padding, encoding the output as GIF, and streaming it directly to a CDN endpoint.
 * 5. When a reporting tool embeds rotated product images into PDF reports, saving the rotated JPEG as a GIF in a MemoryStream to embed without persisting intermediate files.
 */