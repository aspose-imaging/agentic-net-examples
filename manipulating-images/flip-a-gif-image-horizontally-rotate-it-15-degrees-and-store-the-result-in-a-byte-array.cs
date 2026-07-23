using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Flip horizontally
                gif.RotateFlip(RotateFlipType.RotateNoneFlipX);
                // Rotate 15 degrees with white background
                gif.Rotate(15f, true, Color.White);

                using (MemoryStream ms = new MemoryStream())
                {
                    GifOptions options = new GifOptions();
                    gif.Save(ms, options);
                    byte[] resultBytes = ms.ToArray();

                    // Optionally write to file
                    File.WriteAllBytes(outputPath, resultBytes);
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
 * 1. When a web developer wants to create a mirrored and slightly rotated animated GIF for a banner and needs the transformed image as a byte array to embed directly into an HTML response.
 * 2. When a mobile app backend must generate a horizontally flipped, 15‑degree rotated GIF thumbnail and store it in a database as binary data.
 * 3. When an e‑learning platform needs to preprocess user‑uploaded GIFs by flipping and rotating them before saving the result to a CDN, using C# and Aspose.Imaging.
 * 4. When a desktop application requires on‑the‑fly manipulation of GIF animations—flipping, rotating, and retrieving the result as a byte[] for further processing or transmission.
 * 5. When an email marketing system must adjust the orientation of animated GIFs (flip and rotate) and embed the final image bytes into MIME messages without writing intermediate files.
 */