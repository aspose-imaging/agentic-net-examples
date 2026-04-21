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
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\sample.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document from a file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Prepare TIFF save options with default multi-page settings (all pages)
            TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
            saveOptions.MultiPageOptions = new DjvuMultiPageOptions();

            // Save all pages as a multipage TIFF file
            djvuImage.Save(outputPath, saveOptions);
        }
    }
}