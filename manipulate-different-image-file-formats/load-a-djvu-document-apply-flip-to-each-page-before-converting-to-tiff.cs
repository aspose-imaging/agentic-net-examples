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
        // Hardcoded input and output paths
        string inputPath = "input/input.djvu";
        string outputPath = "output/output.tif";

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
            // Apply flip to each page
            foreach (Image page in djvu.Pages)
            {
                page.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }

            // Save the flipped document as a multi-page TIFF
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            djvu.Save(outputPath, tiffOptions);
        }
    }
}