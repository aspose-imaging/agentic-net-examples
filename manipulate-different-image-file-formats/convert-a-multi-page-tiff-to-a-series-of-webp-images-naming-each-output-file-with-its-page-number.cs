using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output locations
            string inputPath = @"C:\Images\multipage.tif";
            string outputDirectory = @"C:\Images\WebPPages";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Frames collection
                TiffImage tiffImage = (TiffImage)image;
                TiffFrame[] frames = tiffImage.Frames;

                // Iterate over each frame and save it as a separate WebP file
                for (int i = 0; i < frames.Length; i++)
                {
                    // Build the output file path using the page number (starting at 0)
                    string outputPath = Path.Combine(outputDirectory, $"page_{i}.webp");

                    // Ensure the directory for this file exists (covers cases where outputDirectory might be a deeper path)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as WebP
                    // WebPOptions provides default encoding settings; adjust if needed
                    frames[i].Save(outputPath, new WebPOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}