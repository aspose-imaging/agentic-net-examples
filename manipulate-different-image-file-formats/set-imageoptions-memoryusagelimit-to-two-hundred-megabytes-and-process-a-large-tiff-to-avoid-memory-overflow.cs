using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\large.tif";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF with a memory buffer limit of 200 MB
            var loadOptions = new LoadOptions
            {
                BufferSizeHint = 200 // limit internal buffers to 200 MB
            };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Save the image as PNG, also respecting the 200 MB buffer limit
                var pngOptions = new PngOptions
                {
                    BufferSizeHint = 200
                };

                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}