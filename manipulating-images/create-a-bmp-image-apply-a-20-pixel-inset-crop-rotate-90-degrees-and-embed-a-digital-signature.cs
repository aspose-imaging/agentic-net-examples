using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input\\source.bmp";
            string outputPath = "output\\result.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP image if it does not exist
            if (!File.Exists(inputPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(inputPath));
                using (BmpImage bmp = new BmpImage(200, 200))
                {
                    // Fill with white background
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            bmp.SetPixel(x, y, Color.White);
                        }
                    }
                    bmp.Save(inputPath);
                }
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load, process, and save the image
            using (BmpImage image = (BmpImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                // Apply a 20-pixel inset crop
                image.Crop(20, 20, 20, 20);

                // Rotate 90 degrees
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Embed digital signature with a valid password
                image.EmbedDigitalSignature("secure123");

                // Save the final image
                image.Save(outputPath);
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
 * 1. When a desktop application needs to generate a blank BMP canvas, trim a uniform 20‑pixel border, rotate the artwork for portrait layout, and protect the file with a password‑based digital signature before saving it to a user‑specified folder.
 * 2. When an automated reporting tool creates BMP charts, removes a 20‑pixel margin to align the visual with a template, rotates the image to match page orientation, and embeds a secure signature to verify the report’s authenticity.
 * 3. When a document management system processes scanned BMP documents, crops out scanner edges, rotates the pages to the correct reading direction, and adds a digital signature so that downstream auditors can confirm the file has not been altered.
 * 4. When a game asset pipeline needs to produce BMP textures, automatically trim excess padding, rotate the texture for engine‑specific coordinate systems, and embed a signature to prevent tampering of the asset files.
 * 5. When a batch script prepares BMP icons for a Windows installer, crops a consistent inset, rotates the icons to meet UI guidelines, and embeds a password‑protected digital signature to ensure the installer distributes only verified images.
 */