using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\large.cmx";
        string outputDirectory = @"C:\output\";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (unconditional)
        Directory.CreateDirectory(outputDirectory);

        // Configure load options for optimal memory usage
        var loadOptions = new Aspose.Imaging.ImageLoadOptions.CmxLoadOptions
        {
            OptimalMemoryUsage = true,
            // Optional: hint for internal buffer size (e.g., 4 MB)
            BufferSizeHint = 4 * 1024 * 1024
        };

        // Load the CMX image using the specified options
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath, loadOptions))
        {
            // Iterate through each page without caching the whole document
            for (int i = 0; i < cmxImage.PageCount; i++)
            {
                // Retrieve the current page
                CmxImagePage page = (CmxImagePage)cmxImage.Pages[i];

                // Build output file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG using default options
                page.Save(outputPath, new PngOptions());
            }
        }
    }
}