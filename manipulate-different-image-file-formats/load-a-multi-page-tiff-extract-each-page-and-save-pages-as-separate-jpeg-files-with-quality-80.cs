using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputDir = @"C:\Images\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (will be called before each save as required)
        Directory.CreateDirectory(outputDir);

        // Load the multi‑page TIFF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access pages
            TiffImage tiffImage = image as TiffImage;
            if (tiffImage == null)
            {
                Console.Error.WriteLine("The loaded image is not a TIFF image.");
                return;
            }

            // Iterate through each page/frame
            for (int i = 0; i < tiffImage.PageCount; i++)
            {
                // Set the current frame as active
                tiffImage.ActiveFrame = tiffImage.Frames[i];

                // Build output file path for this page
                string outputPath = Path.Combine(outputDir, $"page_{i + 1}.jpg");

                // Ensure the directory for this output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // JPEG save options with quality 80
                var jpegOptions = new JpegOptions
                {
                    Quality = 80
                };

                // Save the current page as JPEG
                tiffImage.Save(outputPath, jpegOptions);
            }
        }
    }
}