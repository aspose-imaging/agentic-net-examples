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
            string inputPath = "input.tga";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image, flip vertically, and save as JPEG
            using (TgaImage image = (TgaImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                // Save infers JPEG format from the .jpg extension
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
 * 1. When a game developer needs to correct the orientation of legacy TGA textures before publishing them as JPEG previews for marketing assets.
 * 2. When a scientific imaging pipeline must vertically flip satellite TGA raster data and convert it to JPEG for quick web‑based visualization.
 * 3. When an e‑commerce platform processes user‑uploaded TGA product mockups, flips them to match the display orientation, and saves them as JPEG thumbnails.
 * 4. When a digital archivist automates the preservation of old TGA artwork by flipping it to its proper orientation and converting it to JPEG for archival storage.
 * 5. When a desktop application generates report images from TGA screenshots, applies a vertical flip to align with page layout, and exports them as JPEG for inclusion in PDF documents.
 */