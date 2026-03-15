using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Directory containing source images (any supported format)
        string inputDir = @"C:\temp\input";
        // Directory where PNG files will be written
        string outputDir = @"C:\temp\output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Process each file in the input directory
        foreach (string sourcePath in Directory.GetFiles(inputDir))
        {
            // Load the image using Aspose.Imaging's generic loader
            using (Image image = Image.Load(sourcePath))
            {
                // Use default PNG options to preserve original fidelity
                PngOptions pngOptions = new PngOptions();

                // Construct the output file name with a .png extension
                string outputPath = Path.Combine(
                    outputDir,
                    Path.GetFileNameWithoutExtension(sourcePath) + ".png");

                // Save the loaded image as PNG using the provided Save overload
                image.Save(outputPath, pngOptions);
            }
        }
    }
}