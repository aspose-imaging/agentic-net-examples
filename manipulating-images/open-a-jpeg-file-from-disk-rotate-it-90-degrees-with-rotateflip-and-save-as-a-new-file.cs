using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_rotated.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image, rotate it, and save the result
            using (Image image = Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise without flipping
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the rotated image to the output path
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
 * 1. When a web application needs to display user‑uploaded photos in portrait orientation, a developer can load the JPEG, rotate it 90° with RotateFlip, and save the corrected file.
 * 2. When an automated batch‑processing script prepares product catalog images for printing, it can use Aspose.Imaging to rotate each JPEG 90 degrees clockwise before saving the output.
 * 3. When a mobile‑to‑desktop sync tool receives images taken in landscape mode, the code can rotate the JPEG to match the desktop layout and store the new file.
 * 4. When a digital asset management system must generate thumbnails that require a specific orientation, developers can rotate the source JPEG 90° and save it as a new image for thumbnail creation.
 * 5. When a document generation service embeds photos into PDFs and needs the images oriented correctly, it can programmatically rotate the JPEG using RotateFlip and save the adjusted file for inclusion.
 */