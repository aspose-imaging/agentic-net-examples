using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.CoreExceptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        // Wrap the whole execution to catch any unexpected errors
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\output.psd";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,      // Use RLE compression
                    ColorMode = ColorModes.Grayscale                // Set grayscale color mode
                };

                // Attempt to save the image as PSD and handle PSD‑specific exceptions
                try
                {
                    image.Save(outputPath, psdOptions);
                }
                catch (PsdImageException ex)
                {
                    Console.Error.WriteLine($"PSD processing error: {ex.Message}");
                }
                catch (ImageSaveException ex)
                {
                    Console.Error.WriteLine($"Image save error: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            // Log any other unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a .NET application must convert legacy BMP assets to Photoshop PSD files while ensuring the output uses RLE compression and grayscale color mode, and needs to log any PSD‑specific errors.
 * 2. When an automated image processing pipeline processes user‑uploaded pictures and must safely save them as PSD files on a server, handling missing source files and directory creation errors.
 * 3. When a desktop utility needs to batch‑convert a folder of bitmap images to PSD format and must capture and report image‑save exceptions such as insufficient disk space or unsupported pixel formats.
 * 4. When integrating Aspose.Imaging into a CI/CD build step that validates design assets by converting them to PSD and requires detailed logging of PsdImageException and ImageSaveException failures.
 * 5. When developing a web service that receives BMP data, converts it to a PSD with specific compression and color settings, and must return clear error messages if the conversion or file system operations fail.
 */