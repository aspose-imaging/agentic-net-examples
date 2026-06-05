using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded collection of EPS files to convert
            string[] inputFiles = new string[]
            {
                @"C:\Images\Input1.eps",
                @"C:\Images\Input2.eps",
                @"C:\Images\Input3.eps"
            };

            foreach (var inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output path by changing the extension to .psd
                string outputPath = Path.ChangeExtension(inputPath, ".psd");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EPS image
                using (Image image = Image.Load(inputPath))
                {
                    // Create PSD save options (default settings)
                    var psdOptions = new PsdOptions();

                    // Save the image as PSD
                    image.Save(outputPath, psdOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}