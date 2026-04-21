using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Ensure output directory exists (unconditional as per requirements)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Check pixel count requirement (minimum 200x200)
                    if (image.Width * image.Height < 200 * 200)
                    {
                        // Skip embedding for images that do not meet the size requirement
                        continue;
                    }

                    // Cast to RasterCachedImage to access EmbedDigitalSignature
                    if (image is RasterCachedImage rasterImage)
                    {
                        // Embed digital signature with a valid password
                        rasterImage.EmbedDigitalSignature("secure123");
                        // Save the signed image
                        rasterImage.Save(outputPath);
                    }
                    else if (image is RasterCachedMultipageImage multipageImage)
                    {
                        // Embed digital signature for multipage images
                        multipageImage.EmbedDigitalSignature("secure123");
                        multipageImage.Save(outputPath);
                    }
                    else
                    {
                        // If the image type does not support digital signature, just copy it
                        image.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}