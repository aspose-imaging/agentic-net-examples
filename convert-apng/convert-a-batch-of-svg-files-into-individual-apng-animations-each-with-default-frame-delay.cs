using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input SVG files (batch)
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input\image1.svg",
                @"C:\Images\Input\image2.svg",
                @"C:\Images\Input\image3.svg"
            };

            // Corresponding output APNG files
            string[] outputPaths = new string[]
            {
                @"C:\Images\Output\image1.apng",
                @"C:\Images\Output\image2.apng",
                @"C:\Images\Output\image3.apng"
            };

            // Process each file in the batch
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG and save as APNG with default frame time (e.g., 100 ms)
                using (Image image = Image.Load(inputPath))
                {
                    var apngOptions = new ApngOptions
                    {
                        DefaultFrameTime = 100 // default frame delay in milliseconds
                    };
                    image.Save(outputPath, apngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}