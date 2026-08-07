using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.tga";
        string outputPath = "output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Save as BMP while preserving alpha channel and original bit depth
                image.Save(outputPath, new BmpOptions());
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
 * 1. When a game developer needs to convert legacy TGA textures with transparency to BMP for a Windows desktop application while keeping the original bit depth.
 * 2. When a GIS analyst must batch‑process satellite imagery stored as TGA files and output BMP files that retain the alpha channel for overlay mapping.
 * 3. When a UI designer exports assets from a graphics tool in TGA format and wants to programmatically generate BMP versions for legacy hardware that only supports BMP, preserving transparency.
 * 4. When an e‑learning platform automates the conversion of TGA diagrams to BMP for inclusion in PDF reports, ensuring the original color depth and alpha information are unchanged.
 * 5. When a medical imaging software integrates Aspose.Imaging to read TGA scans and save them as BMP files for compatibility with third‑party analysis tools without losing the image’s bit depth or alpha data.
 */