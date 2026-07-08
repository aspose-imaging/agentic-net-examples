using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.tga";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image, flip vertically, and save as JPEG
            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                // Flip vertically
                tgaImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // Save as JPEG using default JPEG options
                JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When a game developer uses Aspose.Imaging for C# to convert legacy TGA textures that are stored upside‑down into web‑ready JPEG thumbnails for a portfolio site.
 * 2. When an e‑commerce platform employs Aspose.Imaging in a C# service to flip vertically TGA product screenshots and save them as JPEGs for email newsletters.
 * 3. When a scientific imaging application processes TGA microscopy images with Aspose.Imaging, flips them vertically in C#, and outputs JPEG files for research reports.
 * 4. When a digital archivist automates the migration of a TGA asset library using Aspose.Imaging for C#, ensuring each image is vertically flipped before being archived as JPEG.
 * 5. When a mobile app generates preview images from TGA assets by using Aspose.Imaging in C# to flip the image vertically and export a compressed JPEG for faster loading.
 */