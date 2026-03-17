using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ImageConverter
{
    static void Main()
    {
        // Directory containing source images (any supported format)
        string sourceDir = @"C:\SourceImages";

        // Directory where PNG files will be saved
        string targetDir = @"C:\PngOutput";

        // Ensure the output directory exists
        Directory.CreateDirectory(targetDir);

        // Process each file in the source directory
        foreach (string sourcePath in Directory.GetFiles(sourceDir))
        {
            // Load the image using Aspose.Imaging's built‑in loader (handles all supported formats)
            using (Image image = Image.Load(sourcePath))
            {
                // Build the output file name with a .png extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string targetPath = Path.Combine(targetDir, fileNameWithoutExt + ".png");

                // Save the image as PNG using default PNG options (preserves fidelity)
                image.Save(targetPath, new PngOptions());
            }
        }

        Console.WriteLine("Conversion completed.");
    }
}