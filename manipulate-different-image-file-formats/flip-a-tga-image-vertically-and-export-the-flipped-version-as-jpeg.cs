using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\source.tga";
            string outputPath = @"C:\Images\output\flipped.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image, flip it vertically, and save as JPEG
            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                // Perform a vertical flip
                tgaImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // Save the flipped image as JPEG
                var jpegOptions = new JpegOptions();
                tgaImage.Save(outputPath, jpegOptions);
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
 * 1. When a game developer needs to convert legacy TGA textures to JPEG for web preview and must flip them vertically to match the coordinate system of the target platform.
 * 2. When a digital archivist processes scanned TGA screenshots from an old graphics workstation and wants to correct upside‑down orientation before storing them as compressed JPEG files.
 * 3. When a UI designer automates the generation of thumbnail previews from TGA assets, applying a vertical flip to align with the display orientation of a mobile app and saving them as JPEG for faster loading.
 * 4. When a scientific imaging application receives TGA images from a microscope that are stored with inverted Y‑axis, and the code flips them vertically and converts to JPEG for inclusion in reports.
 * 5. When a batch‑processing script needs to read TGA files, apply a vertical RotateFlip operation using Aspose.Imaging for .NET, and export the results as JPEG to reduce file size for email distribution.
 */