using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Ensure the output directory exists (creates if missing)
            Directory.CreateDirectory(outputDirectory);

            // Process each TIFF file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.tif"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, rotate, and save as PNG
                using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
                {
                    // Rotate 90 degrees clockwise, resize proportionally, black background
                    tiffImage.Rotate(90f, true, Aspose.Imaging.Color.Black);

                    // Save as PNG using default options
                    tiffImage.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}