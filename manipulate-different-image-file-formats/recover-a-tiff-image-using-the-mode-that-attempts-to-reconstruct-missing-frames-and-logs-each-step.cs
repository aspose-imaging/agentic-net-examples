using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output\\recovered.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            Console.WriteLine("Loading image with recovery options...");

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                Console.WriteLine("Image loaded.");

                if (image is TiffImage tiffImage)
                {
                    Console.WriteLine($"Number of frames: {tiffImage.Frames.Length}");
                }
                else
                {
                    Console.WriteLine("Loaded image is not a TIFF.");
                }

                Console.WriteLine("Saving recovered image...");
                image.Save(outputPath);
                Console.WriteLine($"Image saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}