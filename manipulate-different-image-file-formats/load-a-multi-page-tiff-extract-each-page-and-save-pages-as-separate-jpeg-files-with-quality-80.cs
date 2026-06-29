using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output locations
        string inputPath = @"C:\Images\multipage.tif";
        string outputDir = @"C:\Images\output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access individual frames
                TiffImage tiff = image as TiffImage;
                if (tiff == null)
                {
                    Console.Error.WriteLine("The loaded file is not a TIFF image.");
                    return;
                }

                // Iterate over each frame and save as JPEG with quality 80
                for (int i = 0; i < tiff.Frames.Length; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.jpg");

                    // Ensure the directory for this output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // JPEG options with the required quality
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 80
                    };

                    // Save the current frame as a JPEG file
                    tiff.Frames[i].Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to extract each page from a multi‑page TIFF scanned document and generate separate JPEG files for web preview with a specific quality setting of 80 using Aspose.Imaging for .NET.
 * 2. When an application must automate the conversion of medical imaging TIFF stacks into compressed JPEG images for faster transmission to remote diagnostic tools.
 * 3. When a digital archiving system requires breaking down large TIFF bundles into individual JPEG pages while preserving image quality control in a C# batch‑processing routine.
 * 4. When a reporting tool has to create thumbnail‑style JPEG extracts from each page of a multi‑page TIFF invoice to embed in email summaries.
 * 5. When a developer is building a migration script that moves legacy TIFF assets to a JPEG‑based content management system, needing per‑page extraction and quality‑adjusted saving in C#.
 */