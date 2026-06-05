using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cmx";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load CMX image with optimal memory usage hint
            var loadOptions = new CmxLoadOptions
            {
                OptimalMemoryUsage = true
            };

            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath, loadOptions))
            {
                int pageIndex = 0;
                foreach (Image page in cmxImage.Pages)
                {
                    // Cast to CmxImagePage for saving
                    using (CmxImagePage cmxPage = (CmxImagePage)page)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");

                        // Ensure directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        cmxPage.Save(outputPath, new PngOptions());
                    }

                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}