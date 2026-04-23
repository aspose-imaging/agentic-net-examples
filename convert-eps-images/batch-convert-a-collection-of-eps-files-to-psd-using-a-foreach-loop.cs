using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input EPS files collection
        string[] epsFiles = new string[]
        {
            @"C:\Images\Input1.eps",
            @"C:\Images\Input2.eps",
            @"C:\Images\Input3.eps"
        };

        // Hardcoded output directory
        string outputDir = @"C:\Images\Converted";

        foreach (string inputPath in epsFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output PSD path
            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".psd");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PSD save options
                var psdOptions = new PsdOptions();

                // Save as PSD
                image.Save(outputPath, psdOptions);
            }
        }
    }
}