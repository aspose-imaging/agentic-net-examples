using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_rotated.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate the image 90 degrees clockwise
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
 * 1. When a web application needs to automatically correct portrait‑mode photos uploaded by users, a developer can use this code to load the JPEG, rotate it 90° clockwise, and save the corrected image for display.
 * 2. When generating printable product catalogs, a developer may need to rotate product photos taken sideways so they fit the layout, using the C# RotateFlip method on JPEG files before saving the final version.
 * 3. When building a batch‑processing tool that normalizes scanned documents stored as JPEGs, the code can be invoked to rotate each page 90 degrees and write the output to a designated folder.
 * 4. When integrating a mobile‑to‑desktop workflow where images captured on a phone appear rotated, a developer can use this snippet to programmatically fix the orientation of the JPEG before further processing.
 * 5. When creating a thumbnail‑generation service that requires all source images to have a consistent orientation, the developer can load each JPEG, apply a 90‑degree rotation, and save the adjusted file for downstream resizing.
 */