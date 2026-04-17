using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\InputCdr";
        string outputFolder = @"C:\OutputJpg";

        // Process each CDR file in the input folder
        foreach (string inputPath in Directory.GetFiles(inputFolder, "*.cdr"))
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Base name for output files (one per page)
                string outputBase = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath));

                // Iterate through all pages of the CDR document
                for (int i = 0; i < cdrImage.PageCount; i++)
                {
                    var page = (CdrImagePage)cdrImage.Pages[i];
                    string outputPath = $"{outputBase}_page{i}.jpg";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as JPG using default options
                    JpegOptions jpegOptions = new JpegOptions();
                    page.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}