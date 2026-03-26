using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output directories
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all WMF files in the input directory
        string[] wmfFiles = Directory.GetFiles(inputDirectory, "*.wmf");

        foreach (string inputPath in wmfFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output file paths for each target format
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string pngPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");
            string jpegPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");
            string bmpPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");

            // Ensure directories for each output file exist
            Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(jpegPath));
            Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

            // Load the WMF image and save to each format
            using (Image image = Image.Load(inputPath))
            {
                image.Save(pngPath, new PngOptions());
                image.Save(jpegPath, new JpegOptions());
                image.Save(bmpPath, new BmpOptions());
            }
        }
    }
}