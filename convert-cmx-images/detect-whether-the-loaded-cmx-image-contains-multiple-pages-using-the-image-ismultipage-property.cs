using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "sample.cmx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load CMX image and check if it contains multiple pages
        using (CmxImage image = (CmxImage)Image.Load(inputPath))
        {
            bool isMultiPage = false;
            if (image is IMultipageImage multipageImage)
            {
                isMultiPage = multipageImage.PageCount > 1;
            }
            Console.WriteLine($"Is multi-page: {isMultiPage}");
        }
    }
}