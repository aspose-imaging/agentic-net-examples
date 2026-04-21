using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
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
                    Console.Error.WriteLine("The loaded image is not a TIFF.");
                    return;
                }

                // JPEG save options with quality 80
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 80
                };

                // Iterate through each page/frame
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Hardcoded output path for each page
                    string outputPath = $@"C:\temp\output_page_{i + 1}.jpg";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as a JPEG file
                    tiffImage.Frames[i].Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}