using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputPath = "output.tiff";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu document
        using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
        {
            // Flip each page horizontally
            foreach (Image page in djvu.Pages)
            {
                ((DjvuPage)page).RotateFlip(RotateFlipType.RotateNoneFlipX);
            }

            // Prepare TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the flipped pages as a multi-page TIFF
            djvu.Save(outputPath, tiffOptions);
        }
    }
}