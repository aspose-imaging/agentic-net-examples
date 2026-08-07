using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the TGA image, rotate it, and save as BMP
            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise without flipping
                tgaImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the result; format is inferred from the .bmp extension
                tgaImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a game developer needs to reorient legacy TGA texture assets for a Windows game and convert them to BMP for compatibility with a legacy rendering engine.
 * 2. When an e‑learning platform processes user‑uploaded TGA screenshots, rotates them to the correct orientation, and stores them as BMP files for faster loading in .NET web applications.
 * 3. When a scientific imaging tool receives TGA microscope images that are stored sideways, and the developer must rotate them 90° clockwise and save as BMP for integration with Windows‑based analysis software.
 * 4. When an automation script batch‑processes TGA icons from a design repository, applying a 90° clockwise rotation and converting them to BMP to meet a client’s asset‑delivery specifications.
 * 5. When a .NET desktop application needs to display TGA graphics in a UI component that only supports BMP, requiring a one‑time rotation and format conversion using Aspose.Imaging.
 */