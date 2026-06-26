using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output\converted.bmp";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to BmpImage to access BMP‑specific operations (optional conversion)
                if (image is BmpImage bmpImage)
                {
                    // Example conversion: binarize using Otsu method
                    bmpImage.BinarizeOtsu();
                }

                // Prepare BMP save options (default options are sufficient for most cases)
                BmpOptions saveOptions = new BmpOptions();

                // Save the image to a memory stream to obtain the byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, saveOptions);
                    byte[] imageBytes = ms.ToArray();

                    // For demonstration, write the size of the byte array
                    Console.WriteLine($"Byte array length: {imageBytes.Length}");

                    // Optionally, also save to a physical file using the same options
                    // (demonstrates the required output path handling)
                    ms.Position = 0; // Reset stream position before re‑reading
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        ms.CopyTo(fileStream);
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
 * 1. When a developer needs to embed a processed BMP image into a database column as a BLOB for later retrieval.
 * 2. When a developer wants to send a converted BMP over a Web API as a base‑64 encoded payload.
 * 3. When a developer must cache a binarized BMP in memory to reuse it across multiple threads without writing temporary files.
 * 4. When a developer is generating a thumbnail preview of a BMP and needs the byte array to embed it in a PDF document.
 * 5. When a developer is integrating with a legacy system that accepts BMP data via a socket stream and requires the image as a byte array after Otsu binarization.
 */