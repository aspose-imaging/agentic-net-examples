using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\sample_rotated.emf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CmxImage to access vector-specific methods
                var cmxImage = image as CmxImage;
                if (cmxImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not a CMX image.");
                    return;
                }

                // Rotate 90 degrees clockwise
                cmxImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Set up EMF rasterization options (page size matches the rotated image)
                var emfRasterOptions = new EmfRasterizationOptions
                {
                    PageSize = cmxImage.Size
                };

                // Create EMF save options with the rasterization settings
                var emfOptions = new EmfOptions
                {
                    VectorRasterizationOptions = emfRasterOptions
                };

                // Save the rotated image as EMF
                cmxImage.Save(outputPath, emfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}