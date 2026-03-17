using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class TiffToApngBatchConverter
{
    // Entry point
    static void Main()
    {
        // Folder containing TIFF files
        string inputFolder = @"C:\Images\TiffInput";
        // Folder to store generated APNG files
        string outputFolder = @"C:\Images\ApngOutput";

        // Ensure output directory exists
        Directory.CreateDirectory(outputFolder);

        // Get all TIFF files (both .tif and .tiff extensions)
        string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");
        string[] tiffFilesAlt = Directory.GetFiles(inputFolder, "*.tiff");
        string[] allTiffFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
        tiffFiles.CopyTo(allTiffFiles, 0);
        tiffFilesAlt.CopyTo(allTiffFiles, tiffFiles.Length);

        // Process each TIFF file
        foreach (string tiffPath in allTiffFiles)
        {
            // Load the TIFF image (multi‑page TIFF is supported)
            using (Image tiffImage = Image.Load(tiffPath))
            {
                // Determine output file name (same base name with .png extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(tiffPath);
                string apngPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Save as APNG with a default frame duration (e.g., 500 ms)
                tiffImage.Save(apngPath, new ApngOptions() { DefaultFrameTime = 500 });
            }
        }

        Console.WriteLine("Batch conversion completed.");
    }
}