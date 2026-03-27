using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Define input DjVu files, corresponding page ranges, and output BMP files.
        string[] inputPaths = { "input1.djvu", "input2.djvu" };
        IntRange[] pageRanges = { new IntRange(1, 3), new IntRange(2, 4) };
        string[] outputPaths = { "output1.bmp", "output2.bmp" };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];
            IntRange range = pageRanges[i];

            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu image from file stream.
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure BMP save options with the desired page range.
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.MultiPageOptions = new DjvuMultiPageOptions(range);

                // Save selected pages as BMP.
                djvuImage.Save(outputPath, bmpOptions);
            }
        }
    }
}