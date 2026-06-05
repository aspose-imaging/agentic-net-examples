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
            string outputPath = "output.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image, rotate 90° clockwise, and save as BMP
            using (Image image = Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise without flipping
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save using the .bmp extension; format is inferred from the file name
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
 * 1. When a game developer needs to convert legacy TGA sprite sheets into BMP textures for a Windows desktop game and must rotate them 90° clockwise to match the new rendering orientation.
 * 2. When a GIS analyst receives aerial imagery in TGA format that is stored sideways and wants to rotate it clockwise and save as BMP for compatibility with legacy mapping software.
 * 3. When an e‑learning content creator has TGA diagrams exported from a design tool, needs to reorient them for slide layouts, and must output BMP files that can be embedded in PowerPoint.
 * 4. When a printer driver integration requires BMP images, and the source assets are TGA files captured from a camera that need a 90° clockwise rotation before printing.
 * 5. When an automated build pipeline processes TGA assets, applies a clockwise rotation to align UI elements, and stores the result as BMP for use in a .NET WinForms application.
 */