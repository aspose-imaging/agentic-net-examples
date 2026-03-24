using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input vector file path
        string inputPath = "input.cdr";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Directory where extracted images will be saved
        string outputDir = "extracted_images";

        // Ensure the output directory exists (unconditional as required)
        Directory.CreateDirectory(Path.GetDirectoryName(outputDir) ?? outputDir);

        // Load the vector image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast to VectorImage to access embedded images
            VectorImage vectorImage = (VectorImage)image;
            EmbeddedImage[] embeddedImages = vectorImage.GetEmbeddedImages();

            int index = 0;
            foreach (EmbeddedImage embedded in embeddedImages)
            {
                // Build output file path for each extracted image
                string outputPath = Path.Combine(outputDir, $"image{index}.png");

                // Ensure the directory for this output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Save the embedded raster image as PNG preserving original quality
                using (embedded)
                {
                    embedded.Image.Save(outputPath, new PngOptions());
                }

                index++;
            }
        }
    }
}