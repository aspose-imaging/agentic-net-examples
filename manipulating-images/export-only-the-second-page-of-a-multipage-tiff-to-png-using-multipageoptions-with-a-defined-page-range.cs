using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\multipage.tif";
        string outputPath = @"C:\Images\page2.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multipage TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options with MultiPageOptions to export only the second page (index 1)
            var pngOptions = new PngOptions
            {
                MultiPageOptions = new MultiPageOptions(new int[] { 1 })
            };

            // Save the selected page as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}