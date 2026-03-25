using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input PNG files
        string[] inputFiles = {
            "input1.png",
            "input2.png"
        };

        // Output directory for APNG files
        string outputDirectory = "output";

        // Report file path
        string reportPath = "report.txt";

        // Initialize report
        File.WriteAllText(reportPath, string.Empty);

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output APNG path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".apng");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            try
            {
                // Load source PNG as RasterImage
                using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
                {
                    // Configure APNG creation options
                    ApngOptions createOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = 500, // 500 ms per frame
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    // Create APNG image canvas
                    using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
                    {
                        // Remove default frame and add the source image as the only frame
                        apngImage.RemoveAllFrames();
                        apngImage.AddFrame(sourceImage);

                        // Save the APNG file
                        apngImage.Save();
                    }
                }

                // Log success
                File.AppendAllText(reportPath, $"{inputPath} -> {outputPath}: Success{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Log failure
                File.AppendAllText(reportPath, $"{inputPath} -> {outputPath}: Failed - {ex.Message}{Environment.NewLine}");
            }
        }
    }
}