using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DjVu files
            string[] inputFiles = new[]
            {
                @"C:\Input\sample1.djvu",
                @"C:\Input\sample2.djvu",
                @"C:\Input\sample3.djvu"
            };

            // Process each file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output TIFF path
                string outputDirectory = @"C:\Output";
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".tif";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu document
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                {
                    // Configure TIFF save options for multipage output
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        Compression = TiffCompressions.Deflate,
                        BitsPerSample = new ushort[] { 1 },
                        MultiPageOptions = new DjvuMultiPageOptions()
                    };

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