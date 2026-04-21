using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.pdf";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multipage PDF once
            using (Image image = Image.Load(inputPath))
            {
                // Loop over pages 1‑3 (zero‑based indices 0,1,2)
                for (int pageIndex = 0; pageIndex < 3; pageIndex++)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page{pageIndex + 1}.tiff");

                    // Ensure the directory for this output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure TIFF save options with a single page range
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new int[] { pageIndex });

                    // Save the selected page as a separate TIFF file
                    image.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}