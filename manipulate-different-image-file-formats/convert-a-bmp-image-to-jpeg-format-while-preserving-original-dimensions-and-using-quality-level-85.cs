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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with quality 85
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = 85,
                    BitsPerChannel = 8 // preserve standard 8‑bit per channel
                };

                // Save as JPEG preserving original dimensions
                image.Save(outputPath, saveOptions);
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
 * 1. When a desktop application needs to reduce the file size of user‑uploaded BMP screenshots for web display while keeping the original width and height, a developer can use this code to convert them to JPEG with quality 85.
 * 2. When an automated batch‑processing service must archive legacy BMP assets into a more storage‑efficient JPEG format without altering image dimensions, the snippet provides the required C# conversion.
 * 3. When a photo‑editing tool exports edited BMP layers to a final JPEG output for sharing on social media, the code ensures the dimensions stay the same and the compression quality is set to 85.
 * 4. When a document‑generation system embeds images and requires all pictures to be in JPEG to meet PDF/A compliance, the developer can convert each BMP using this routine while preserving size.
 * 5. When a game‑modding utility prepares texture files by converting BMP textures to JPEG to improve loading speed, the example shows how to perform the conversion in .NET with a fixed quality level.
 */