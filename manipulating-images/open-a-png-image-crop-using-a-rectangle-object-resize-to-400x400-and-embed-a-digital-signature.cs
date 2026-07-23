using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

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

            // Load PNG as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Cache data for better performance
                if (!image.IsCached)
                    image.CacheData();

                // Crop the image using a Rectangle (example values)
                var cropRect = new Rectangle(50, 50, 200, 200);
                image.Crop(cropRect);

                // Resize to 400x400 pixels
                image.Resize(400, 400);

                // Embed a digital signature with a valid password
                image.EmbedDigitalSignature("secure123");

                // Save the processed image
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
 * 1. When a web application needs to generate a thumbnail of a user‑uploaded PNG, crop a specific region, resize it to 400 × 400 pixels, and protect the result with a digital signature.
 * 2. When an e‑commerce platform must prepare product images by extracting a central area from a PNG, scaling it to a standard size, and embedding a signature to verify authenticity.
 * 3. When a document management system processes scanned PNG receipts, crops out the relevant portion, resizes it for consistent storage, and signs the file to ensure integrity.
 * 4. When a mobile app creates profile picture avatars from PNG files, automatically crops a defined rectangle, resizes to 400 × 400, and adds a digital signature for secure sharing.
 * 5. When a compliance tool needs to batch‑process PNG screenshots, crop confidential sections, resize them for reporting, and embed a password‑protected signature to meet audit requirements.
 */