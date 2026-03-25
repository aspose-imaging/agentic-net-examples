using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input BMP files
        string[] inputPaths = new string[]
        {
            @"C:\Images\input1.bmp",
            @"C:\Images\input2.bmp"
        };

        // Corresponding output SVG files
        string[] outputPaths = new string[]
        {
            @"C:\Images\output1.svg",
            @"C:\Images\output2.svg"
        };

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

            // Load BMP image
            using (BmpImage bmp = new BmpImage(inputPath))
            {
                // Increase brightness by approximately 10% (26 out of 255)
                bmp.AdjustBrightness(26);

                // Save the brightened image as SVG
                SvgOptions svgOptions = new SvgOptions();
                bmp.Save(outputPath, svgOptions);
            }
        }
    }
}