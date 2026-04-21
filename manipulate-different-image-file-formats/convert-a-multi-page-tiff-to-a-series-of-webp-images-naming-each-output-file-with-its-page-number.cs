using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input TIFF path
            string inputPath = @"C:\temp\input.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multi‑page TIFF image
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The input file is not a TIFF image.");
                    return;
                }

                // Process each frame (page) in the TIFF
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Build output WebP file name using page number (starting at 1)
                    string outputPath = $@"C:\temp\output_page_{i + 1}.webp";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as a WebP image
                    using (var frame = tiffImage.Frames[i])
                    {
                        frame.Save(outputPath, new WebPOptions());
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