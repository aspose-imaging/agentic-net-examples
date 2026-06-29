using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.tga";
            string outputPath = "output\\rotated.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image, rotate 90° clockwise, and save as BMP
            using (TgaImage image = (TgaImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
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
 * 1. When a game developer needs to convert legacy TGA sprite sheets into BMP format and rotate them 90° clockwise for use in a Windows desktop UI.
 * 2. When an e‑commerce platform must preprocess product photos stored as TGA files, rotate them to correct orientation, and save them as BMP thumbnails for legacy reporting tools.
 * 3. When a scientific imaging pipeline receives TGA microscopy images that are oriented incorrectly and must be rotated and saved as BMP for compatibility with older analysis software.
 * 4. When an automation script for a printing service has to batch‑process TGA artwork, rotate each image 90° clockwise, and output BMP files that the printer driver accepts.
 * 5. When a legacy asset migration tool needs to read TGA textures, apply a 90° clockwise rotation, and store the result as BMP so that older .NET applications can load them without additional libraries.
 */