using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input DjVu files
            string[] inputPaths = { "input1.djvu", "input2.djvu" };
            // Corresponding output TIFF files (placed in the 'output' folder)
            string[] outputPaths = {
                Path.Combine("output", "output1.tif"),
                Path.Combine("output", "output2.tif")
            };

            // Process files in parallel
            System.Threading.Tasks.Parallel.For(0, inputPaths.Length, i =>
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu image from file stream
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Configure TIFF save options
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Deflate;
                    // Export all pages of the DjVu document
                    tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                    // Save as multipage TIFF
                    djvuImage.Save(outputPath, tiffOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}