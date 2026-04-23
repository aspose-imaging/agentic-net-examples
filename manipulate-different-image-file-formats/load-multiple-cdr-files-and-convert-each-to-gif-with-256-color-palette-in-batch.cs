using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDirectory = @"C:\InputCdr";
            string outputDirectory = @"C:\OutputGif";

            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output GIF path (same file name, .gif extension)
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".gif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Prepare GIF save options for a 256‑color palette
                    GifOptions gifOptions = new GifOptions
                    {
                        // Palette correction builds the best matching 256‑color palette
                        DoPaletteCorrection = true,
                        // ColorResolution = bits per pixel - 1; 7 => 8 bits => 256 colors
                        ColorResolution = 7
                    };

                    // Save the image (all pages will be exported as animated frames if present)
                    cdrImage.Save(outputPath, gifOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}