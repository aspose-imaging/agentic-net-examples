using System;
using System.IO;
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
            // Hardcoded input DjVu file
            string inputPath = @"C:\Temp\sample.djvu";

            // Hardcoded output directories and files
            string pngOutputDir = @"C:\Temp\png_pages";
            string tiffOutputPath = @"C:\Temp\merged.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(pngOutputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(tiffOutputPath));

            // Load DjVu image from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Convert first three pages to PNG
                int pagesToConvert = Math.Min(3, djvuImage.Pages.Length);
                for (int i = 0; i < pagesToConvert; i++)
                {
                    // Each page is a DjvuPage
                    var djvuPage = (DjvuPage)djvuImage.Pages[i];
                    string pngPath = Path.Combine(pngOutputDir, $"page{i + 1}.png");
                    // Ensure directory for each PNG (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                    djvuPage.Save(pngPath, new PngOptions());
                }

                // Merge the same three pages into a multipage TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                // Optional: set bits per sample for B/W conversion if needed
                tiffOptions.BitsPerSample = new ushort[] { 1 };
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();
                tiffOptions.MultiPageOptions.Pages = new int[] { 0, 1, 2 }; // zero‑based page indices
                // Save the multipage TIFF
                djvuImage.Save(tiffOutputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}