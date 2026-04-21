using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu files
        string[] inputPaths = new[]
        {
            @"C:\Temp\sample1.djvu",
            @"C:\Temp\sample2.djvu"
        };

        // Hardcoded output directory
        string outputDirectory = @"C:\Temp\Output";

        // Process each file in parallel
        Parallel.ForEach(inputPaths, inputPath =>
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output TIFF path
            string outputPath = Path.Combine(outputDirectory,
                Path.GetFileNameWithoutExtension(inputPath) + ".tif");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options for multipage output
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                tiffOptions.BitsPerSample = new ushort[] { 1 }; // optional B/W conversion
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save the DjVu document as a multipage TIFF
                djvuImage.Save(outputPath, tiffOptions);
            }
        });
    }
}