using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input TIFF file path
            string inputPath = @"C:\Images\input.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for BMP frames
            string outputDir = @"C:\Images\Frames";

            // Load the TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame in the TIFF image
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Build output BMP file path for the current frame
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set BMP export options (default options are sufficient)
                    BmpOptions bmpOptions = new BmpOptions();

                    // Save the current frame as BMP
                    tiffImage.Frames[i].Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to extract each page of a multi‑page TIFF file and save them as BMP images for compatibility with legacy Windows applications.
 * 2. When a developer must convert scanned document frames stored in a TIFF archive into BMP format to feed them into a third‑party OCR engine that only accepts BMP files.
 * 3. When a developer wants to generate individual BMP thumbnails from a multi‑frame TIFF to display in a .NET WinForms image gallery that only supports BMP resources.
 * 4. When a developer is preparing image assets for a printing workflow that requires BMP files, and the source artwork is delivered as a multi‑page TIFF.
 * 5. When a developer needs to batch‑process a TIFF file on a server, separating its frames into separate BMP files for downstream processing in a C# image‑analysis pipeline.
 */