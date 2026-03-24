using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageOptions;

namespace TgaProcessingDemo
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.tga";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (any supported raster format)
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Convert the raster image to a TGA image
                using (TgaImage tga = new TgaImage(raster))
                {
                    // Edit some TGA metadata
                    tga.AuthorName = "John Doe";
                    tga.AuthorComments = "Sample TGA conversion";
                    tga.ImageId = "DemoImage001";
                    tga.SoftwareId = "Aspose.Imaging";
                    tga.SoftwareVersion = "23.5";
                    tga.XOrigin = 0;
                    tga.YOrigin = 0;

                    // Save the TGA image using default options
                    tga.Save(outputPath);
                }
            }

            // Demonstrate loading an existing TGA, modifying metadata, and re‑saving
            string editInputPath = "existing.tga";
            string editOutputPath = "edited.tga";

            if (!File.Exists(editInputPath))
            {
                Console.Error.WriteLine($"File not found: {editInputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(editOutputPath));

            using (TgaImage existingTga = (TgaImage)Image.Load(editInputPath))
            {
                // Update metadata fields
                existingTga.AuthorName = "Jane Smith";
                existingTga.JobNameOrId = "MetadataUpdateJob";
                existingTga.JobTime = TimeSpan.FromHours(2);
                existingTga.TransparentColor = Color.FromArgb(255, 0, 255, 0); // Green key color

                // Save the modified TGA image
                existingTga.Save(editOutputPath);
            }
        }
    }
}