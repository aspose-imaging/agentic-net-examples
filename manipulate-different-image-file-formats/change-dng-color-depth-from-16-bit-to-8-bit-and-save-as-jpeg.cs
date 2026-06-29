using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"c:\temp\input.dng";
            string outputPath = @"c:\temp\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG options (JPEG is 8‑bit per channel by default)
                var jpegOptions = new JpegOptions
                {
                    Quality = 90 // optional quality setting
                };

                // Save as JPEG, effectively converting from 16‑bit to 8‑bit
                image.Save(outputPath, jpegOptions);
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
 * 1. When a photographer needs to generate web‑ready thumbnails from high‑resolution 16‑bit DNG raw files, they can use this code to convert the images to 8‑bit JPEGs for faster loading.
 * 2. When an e‑commerce platform must display product photos captured in DNG format on browsers that only support 8‑bit JPEG, the code enables batch conversion to a compatible format.
 * 3. When a mobile app processes raw camera captures and must reduce file size before uploading, developers can apply this snippet to down‑sample the color depth and save as a compressed JPEG.
 * 4. When a digital archiving system stores original 16‑bit DNG files but needs to provide low‑resolution preview images for users, the code creates 8‑bit JPEG previews on demand.
 * 5. When a content management workflow requires converting raw DNG assets to standard JPEGs for printing or sharing, this example shows how to perform the conversion in C# using Aspose.Imaging.
 */