using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input DjVu files
        string[] inputFiles = new string[]
        {
            "Input/file1.djvu",
            "Input/file2.djvu",
            "Input/file3.djvu"
        };

        // Process each file in parallel
        System.Threading.Tasks.Parallel.ForEach(inputFiles, inputPath =>
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output TIFF path
            string outputPath = Path.Combine("Output", Path.GetFileNameWithoutExtension(inputPath) + ".tif");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu image from stream and convert to multipage TIFF
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(); // Export all pages

                // Save as multipage TIFF
                djvuImage.Save(outputPath, tiffOptions);
            }
        });
    }
}